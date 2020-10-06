using System;
using System.Collections.Generic;
using System.Text;

namespace FortyThreeLime.Models.Domain
{
    /// <summary>
    /// Classes implementing this interface will generate various unique key entities
    /// </summary>
    /// <typeparam name="T">Type of Key Generated</typeparam>
    public interface IKeyGenerator<T>
    {
        T Generate();
    }

    /// <summary>
    /// Classes implementing this interface generate unique string keys
    /// </summary>
    public interface IStringKeyGenerator : IKeyGenerator<string>
    {

    }

    /// <summary>
    /// Options for String Key Generator
    /// </summary>
    public sealed class StringKeyGeneratorOptions
    {
        /// <summary>
        /// Defaults:
        /// Length: 12
        /// Caps: false
        /// Numbers: true
        /// SpecialChars: false
        /// </summary>
        public StringKeyGeneratorOptions()
        {
            this.Length = 12;
            this.IncludeCaps = false;
            this.IncludeDigits = true;
            this.IncludeSpecialChars = false;
        }

        /// <summary>
        /// Include Upper Case Letters
        /// </summary>
        public bool IncludeCaps { get; set; }

        /// <summary>
        /// Include Digits 1-9
        /// </summary>
        public bool IncludeDigits { get; set; }

        /// <summary> Include ['#', '$', '@', '*', '&', '%', '!', '^', '/', '+', '-'] </summary>
        public bool IncludeSpecialChars { get; set; }

        /// <summary>
        /// The Total Length of the String Key To Be Returned
        /// </summary>
        public int Length { get; set; }

        public override string ToString()
        {
            return String.Format("Length: {0}, Caps: {1}, Numbers: {2}, Chars: {3}",
                         this.Length.ToString(),
                         this.IncludeCaps.ToString(),
                         this.IncludeDigits.ToString(),
                         this.IncludeSpecialChars.ToString()
                     );
        }
    }

    /// <summary>
    /// String Key Generator
    /// </summary>
    public sealed class StringKeyGenerator : IStringKeyGenerator
    {
        private readonly bool _IncludeCaps;
        private readonly bool _IncludeNumbers;
        private readonly bool _IncludeSpecialChars;
        private readonly int _Length;

        private readonly char[] _Letters = new char[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'p', 'q', 'r', 's', 't', 'u', 'v', 'l', 'm', 'n', 'o', 'x', 'y', 'z', 'i', 'j', 'k', 'w',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'L', 'M', 'N', 'O', 'X', 'Y', 'Z', 'I', 'J', 'K', 'W'
        };

        private readonly char[] _SpecialCharacters = new char[]
        {
            '#', '$', '@', '*', '&', '%', '!', '+', '-'
        };

        public StringKeyGenerator(StringKeyGeneratorOptions options)
        {
            this._Length = options.Length;
            this._IncludeCaps = options.IncludeCaps;
            this._IncludeNumbers = options.IncludeDigits;
            this._IncludeSpecialChars = options.IncludeSpecialChars;
        }

        internal StringKeyGenerator()
        {
        }

        /// <summary>
        /// Generate a Unique String Key Based on The Parameters Specified
        /// </summary>
        public string Generate()
        {
            //Get A Character Sequence of the Length Specified. Also, contains Caps and/or Numbers as Specified
            string str = GetRandomCharacterSequence();

            //Make sure first char is a letter
            char c1 = GetRandomLetter();
            str = str.Remove(0, 1).Insert(0, c1.ToString()).Trim();

            if (str.Length == this._Length)
            {
                return str;
            }
            else
            {
                throw new Exception("String Key Generation Error! Length of Generated String Does Not Meet Requirements");
            }
        }

        private int GetRandomDigit()
        {
            return RandomNumberGenerator.Uniform(10);
        }

        private char GetRandomLetter()
        {
            //if IncludeCaps = true, n = 52, else n = 26
            int n = this._IncludeCaps == true ? 52 : 26;

            int i = RandomNumberGenerator.Uniform(0, n);
            return _Letters[i];
        }

        private char GetRandomSpecialCharacter()
        {
            int n = _SpecialCharacters.Length;

            int i = RandomNumberGenerator.Uniform(0, n);
            return _SpecialCharacters[i];
        }

        private string GetRandomCharacterSequence()
        {
            StringBuilder sb = new StringBuilder();
            int l = 0;

            while (l < this._Length)
            {
                if (this._IncludeNumbers == true && this._IncludeSpecialChars == true)
                {
                    // 1/2 chance of a letter, 1/3 chance of a number, 1/6 chance of a char
                    int n = RandomNumberGenerator.Uniform(1, 6);
                    switch (n)
                    {
                        case 1:
                        case 4:
                        case 6:
                        default:
                            sb.Append(GetRandomLetter().ToString());
                            break;

                        case 2:
                        case 5:
                            sb.Append(GetRandomDigit().ToString());
                            break;

                        case 3:
                            sb.Append(GetRandomSpecialCharacter().ToString());
                            break;
                    }
                }
                else if (this._IncludeNumbers == true && this._IncludeSpecialChars == false)
                {
                    // 1/3 chance of a letter
                    sb.Append(RandomNumberGenerator.Uniform(1, 3) == 1 ? GetRandomDigit().ToString() : GetRandomLetter().ToString());
                }
                else if (this._IncludeNumbers == false && this._IncludeSpecialChars == true)
                {
                    // 1/3 chance of a special char
                    sb.Append(RandomNumberGenerator.Uniform(1, 3) == 1 ? GetRandomSpecialCharacter().ToString() : GetRandomSpecialCharacter().ToString());
                }
                else
                {
                    sb.Append(GetRandomLetter());
                }

                l++;
            }

            return sb.ToString().Trim();
        }
    }
}
