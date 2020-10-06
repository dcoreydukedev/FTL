/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;

namespace FortyThreeLime.Models.Domain
{
    /// <summary>
    /// The Random class provides static methods for generating random number from various discrete
    /// and continuous distributions, including Bernoulli, uniform, Gaussian, exponential, pareto,
    /// Poisson, and Cauchy. It also provides method for shuffling an array or subarray.
    /// </summary>
    public sealed class RandomNumberGenerator
    {
        private static Random _Random = new Random();
        private static int _Seed = DateTime.Now.Millisecond;

        private RandomNumberGenerator()
        {
        }

        /// <summary>
        /// The seed of the pseudorandom number generator. Using the same seed enables you to
        /// produce the same sequence of "random" number for each execution of the program.
        /// Ordinarily, you should set the seed at most once per program.
        /// </summary>
        public static int Seed
        {
            get { return _Seed; }
            set
            {
                _Seed = value;
                _Random = new Random(_Seed);
            }
        }

        /// <summary>
        /// Returns a random boolean from a Bernoulli distribution with success probability <c>P</c>.
        /// </summary>
        /// <param name="p">p the probability of returning <c>true</c></param>
        /// <returns>
        /// <c>true</c> with probability <c>p</c> and <c>false</c> with probability <c>p</c>
        /// </returns>
        /// <exception cref="ArgumentException">unless <c>p &gt;= 0.0</c> and <c>p &lt;= 1.0</c></exception>
        public static bool Bernoulli(double p)
        {
            if (!(p >= 0.0 && p <= 1.0))
                throw new ArgumentException("Probability must be between 0.0 and 1.0");
            return Uniform() < p;
        }

        /// <summary>
        /// Returns a random boolean from a Bernoulli distribution with success probability 1/2.
        /// </summary>
        /// <returns><c>true</c> with probability 1/2 and <c>false</c> with probability 1/2</returns>
        public static bool Bernoulli()
        {
            return Bernoulli(0.5);
        }

        /// <summary>
        /// Returns a random real number from the Cauchy distribution.
        /// </summary>
        /// <returns>a random real number from the Cauchy distribution.</returns>
        public static double Cauchy()
        {
            return Math.Tan(Math.PI * (Uniform() - 0.5));
        }

        /// <summary>
        /// Returns a random integer from the specified discrete distribution.
        /// </summary>
        /// <param name="probabilities">probabilities the probability of occurrence of each integer</param>
        /// <returns>
        /// a random integer from a discrete distribution: <c>i</c> with probability <c>probabilities[i]</c>
        /// </returns>
        /// <exception cref="ArgumentNullException">if <c>probabilities</c> is <c>null</c></exception>
        /// <exception cref="ArgumentException">
        /// if sum of array entries is not (very nearly) equal to <c>1.0</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// unless <c>probabilities[i] &gt;= 0.0</c> for each index <c>i</c>
        /// </exception>
        public static int Discrete(double[] probabilities)
        {
            if (probabilities == null) throw new ArgumentNullException("Argument array is null");
            double EPSILON = 1E-14;
            double sum = 0.0;
            for (int i = 0; i < probabilities.Length; i++)
            {
                if (!(probabilities[i] >= 0.0))
                    throw new ArgumentException("array entry " + i + " must be nonnegative: " + probabilities[i]);
                sum += probabilities[i];
            }
            if (sum > 1.0 + EPSILON || sum < 1.0 - EPSILON)
                throw new ArgumentException("sum of array entries does not approximately equal 1.0: " + sum);

            // the for loop may not return a value when both r is (nearly) 1.0 and when the
            // cumulative sum is less than 1.0 (as a result of floating-point roundoff error)
            while (true)
            {
                double r = Uniform();
                sum = 0.0;
                for (int i = 0; i < probabilities.Length; i++)
                {
                    sum += probabilities[i];
                    if (sum > r) return i;
                }
            }
        }

        /// <summary>
        /// Returns a random integer from the specified discrete distribution.
        /// </summary>
        /// <param name="frequencies">frequencies the frequency of occurrence of each integer</param>
        /// <returns>
        /// a random integer from a discrete distribution: <c>i</c> with probability proportional to <c>frequencies[i]</c>
        /// </returns>
        /// <exception cref="ArgumentNullException">if <c>frequencies</c> is <c>null</c></exception>
        /// <exception cref="ArgumentException">if all array entries are <c>0</c></exception>
        /// <exception cref="ArgumentException">
        /// if <c>frequencies[i]</c> is negative for any index <c>i</c>
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if sum of frequencies exceeds <c>Integer.MAX_VALUE</c> (2 <sup>31</sup> - 1)
        /// </exception>
        public static int Discrete(int[] frequencies)
        {
            if (frequencies == null) throw new ArgumentNullException("argument array is null");
            long sum = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] < 0)
                    throw new ArgumentException("array entry " + i + " must be nonnegative: " + frequencies[i]);
                sum += frequencies[i];
            }
            if (sum == 0)
                throw new ArgumentException("at least one array entry must be positive");
            if (sum >= int.MaxValue)
                throw new ArgumentException("sum of frequencies overflows an int");

            // pick index i with probability proportional to frequency
            double r = Uniform((int)sum);
            sum = 0;
            for (int i = 0; i < frequencies.Length; i++)
            {
                sum += frequencies[i];
                if (sum > r) return i;
            }

            // can't reach here
            System.Diagnostics.Debug.Assert(false);
            return -1;
        }

        /// <summary>
        /// Returns a random real number from an exponential distribution with rate lambda (λ).
        /// </summary>
        /// <param name="lambda">lambda the rate of the exponential distribution</param>
        /// <returns>a random real number from an exponential distribution with rate <c>lambda</c></returns>
        /// <exception cref="ArgumentException">unless <c>lambda &gt; 0.0</c></exception>
        public static double Exp(double lambda)
        {
            if (!(lambda > 0.0))
                throw new ArgumentException("Rate lambda must be positive");
            return -Math.Log(1 - Uniform()) / lambda;
        }

        /// <summary>
        /// Returns a random real number from a standard Gaussian distribution.
        /// </summary>
        /// <returns>
        /// a random real number from a standard Gaussian distribution (mean 0 and standard
        /// deviation 1).
        /// </returns>
        public static double Gaussian()
        {
            // use the polar form of the Box-Muller transform
            double r, x, y;
            do
            {
                x = Uniform(-1.0, 1.0);
                y = Uniform(-1.0, 1.0);
                r = x * x + y * y;
            } while (r >= 1 || r == 0);
            return x * Math.Sqrt(-2 * Math.Log(r) / r);

            // Remark:  y * Math.sqrt(-2 * Math.log(r) / r) is an independent random gaussian
        }

        /// <summary>
        /// Returns a random real number from a Gaussian distribution with mean mu (μ) and standard
        /// deviation sigma (σ).
        /// </summary>
        /// <param name="mu">mu (μ) the mean</param>
        /// <param name="sigma">sigma (σ) the standard deviation</param>
        /// <returns>
        /// a real number distributed according to the Gaussian distribution with mean <c>mu</c> and
        /// standard deviation <c>sigma</c>
        /// </returns>
        public static double Gaussian(double mu, double sigma)
        {
            return mu + sigma * Gaussian();
        }

        /// <summary>
        /// Returns a random integer from a geometric distribution with success probability <c>P</c>.
        /// </summary>
        /// <param name="p">p the parameter of the geometric distribution</param>
        /// <returns>
        /// a random integer from a geometric distribution with success probability <c>p</c>; or
        /// <c>int.MaxValue</c> if <c>p</c> is (nearly) equal to <c>1.0</c>.
        /// </returns>
        /// <exception cref="ArgumentException">unless <c>p &gt;= 0.0</c> and <c>p &lt;= 1.0</c></exception>
        public static int Geometric(double p)
        {
            if (!(p >= 0.0 && p <= 1.0))
                throw new ArgumentException("Probability must be between 0.0 and 1.0");
            // using algorithm given by Knuth
            return (int)Math.Ceiling(Math.Log(Uniform()) / Math.Log(1.0 - p));
        }

        /// <summary>
        /// Returns a random real number from the standard Pareto distribution.
        /// </summary>
        /// <returns>a random real number from the standard Pareto distribution</returns>
        public static double Pareto()
        {
            return Pareto(1.0);
        }

        /// <summary>
        /// Returns a random real number from a Pareto distribution with shape parameter alpha (α).
        /// </summary>
        /// <param name="alpha">alpha (α) shape parameter</param>
        /// <returns>a random real number from a Pareto distribution with shape parameter <c>alpha</c></returns>
        /// <exception cref="ArgumentException">unless <c>alpha &gt; 0.0</c></exception>
        public static double Pareto(double alpha)
        {
            if (!(alpha > 0.0))
                throw new ArgumentException("Shape parameter alpha must be positive");
            return Math.Pow(1 - Uniform(), -1.0 / alpha) - 1.0;
        }

        /// <summary>
        /// Returns a random integer from a Poisson distribution with mean lambda (λ).
        /// </summary>
        /// <param name="lambda">lambda (λ) the mean of the Poisson distribution</param>
        /// <returns>a random integer from a Poisson distribution with mean <c>lambda</c></returns>
        /// <exception cref="ArgumentException">unless <c>lambda &gt; 0.0</c> and not infinite</exception>
        public static int Poisson(double lambda)
        {
            if (!(lambda > 0.0))
                throw new ArgumentException("Parameter lambda must be positive");
            if (double.IsInfinity(lambda))
                throw new ArgumentException("Parameter lambda must not be infinite");
            // using algorithm given by Knuth see http://en.wikipedia.org/wiki/Poisson_distribution
            int k = 0;
            double p = 1.0;
            double L = Math.Exp(-lambda);
            do
            {
                k++;
                p *= Uniform();
            } while (p >= L);
            return k - 1;
        }

        /// <summary>
        /// Returns a random real number uniformly in [0, 1).
        /// </summary>
        /// <returns>a random real number uniformly in [0, 1)</returns>
        /// <remarks>Deprecated. Use <see cref="Uniform()"/></remarks>
        public static double Random()
        {
            return Uniform();
        }

        /// <summary>
        /// Returns a random real number uniformly in [0, 1).
        /// </summary>
        /// <returns>a random real number uniformly in [0, 1)</returns>
        public static double Uniform()
        {
            return _Random.NextDouble();
        }

        /// <summary>
        /// Returns a random integer uniformly in [0, n).
        /// </summary>
        /// <param name="n">n number of possible integers</param>
        /// <returns>a random integer uniformly between 0 (inclusive) and <c>N</c> (exclusive)</returns>
        /// <exception cref="ArgumentException">if <c>n &lt;= 0</c></exception>
        public static int Uniform(int n)
        {
            if (n <= 0) throw new ArgumentException("Parameter N must be positive");
            return _Random.Next(n);
        }

        /// <summary>
        /// Returns a random integer uniformly in [a, b).
        /// </summary>
        /// <param name="a">a the left endpoint</param>
        /// <param name="b">b the right endpoint</param>
        /// <returns>a random integer uniformly in [a, b)</returns>
        /// <exception cref="ArgumentException">if <c>b &lt;= a</c></exception>
        /// <exception cref="ArgumentException">if <c>b - a &gt;= Integer.MAX_VALUE</c></exception>
        public static int Uniform(int a, int b)
        {
            if (b <= a) throw new ArgumentException("Invalid range");
            if ((long)b - a >= int.MaxValue) throw new ArgumentException("Invalid range");
            return a + Uniform(b - a);
        }

        /// <summary>
        /// Returns a random real number uniformly in [a, b).
        /// </summary>
        /// <param name="a">a the left endpoint</param>
        /// <param name="b">b the right endpoint</param>
        /// <returns>a random real number uniformly in [a, b)</returns>
        /// <exception cref="ArgumentException">unless <c>a &lt; b</c></exception>
        public static double Uniform(double a, double b)
        {
            if (!(a < b)) throw new ArgumentException("Invalid range");
            return a + Uniform() * (b - a);
        }
    }
}