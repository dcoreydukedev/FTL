/*************************************************************************
 * Author: DCoreyDuke
 * Originally from DCoreyDuke.CodeBase
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortyThreeLime.Models.Domain
{
    /// <summary>
    /// Create a Timestamp
    /// </summary>
    /// <remarks>
    /// 1.) A timestamp is a sequence of characters or encoded information identifying when a
    /// certain event occurred, usually giving date and time of day, sometimes accurate to a small
    /// fraction of a second, - Wikipedia 2.) Unix time, the number of seconds since 00:00:00 UTC on
    /// January 1, 1970 - Wikipedia
    /// </remarks>
    [ComplexType, Serializable]
    public class Timestamp
    {
        public Timestamp()
        {
            this.Day = DateTime.Now.Day;
            this.Month = DateTime.Now.Month;
            this.Year = DateTime.Now.Year;
            this.Hour = DateTime.Now.Hour;
            this.Minute = DateTime.Now.Minute;
            this.Second = DateTime.Now.Second;
            this.Millisecond = DateTime.Now.Millisecond;
        }

        public int Day { get; set; }

        public int Hour { get; set; }

        public int Millisecond { get; set; }

        public int Minute { get; set; }

        public int Month { get; set; }

        public int Second { get; set; }

        public int Year { get; set; }

        #region Epoch

        /* Epoch = January 1, 1970 00:00:00 UTC */

        /// <summary>
        /// Number of Milliseconds since Epoch
        /// Most commonly called Unix Timestamp
        /// </summary>
        /// <returns>long EpochTime</returns>
        public long GetEpochTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        /// <summary>
        /// Gets Epoch Time Timestamp
        /// Most Commanly Called Human Readable Format of Epoch Time
        /// </summary>
        /// <returns>string EpochTimestamp</returns>
        public string GetEpochTimestamp()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(GetEpochTime()).ToString("MM/dd/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Gets the epoch timestamp.
        /// </summary>
        /// <param name="epochTime">The epoch time.</param>
        public string GetEpochTimestamp(long epochTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epochTime).ToString("MM/dd/yyyy HH:mm:ss");
        }

        /// <summary>
        /// Gets the date time from epoch.
        /// </summary>
        /// <param name="epochTime">The epoch time.</param>
        public DateTime GetDateTimeFromEpoch(long epochTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epochTime);

        }

        #endregion Epoch

        /// <summary>
        /// Gets The current Timestamp to 4 Milliseconds
        /// </summary>
        /// <returns>MM/dd/yyyy HH:mm:ss:ffff</returns>
        public string GetTimestamp()
        {
            return GetTimestamp("MM/dd/yyyy HH:mm:ss:ffff");
        }


        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns>MM/dd/yyyy HH:mm:ss:ffff</returns>
        public override string ToString()
        {
            return $"{this.Month}/{this.Day}/{this.Year} {this.Hour}:{this.Minute}:{this.Second}:{this.Millisecond}";
        }

        #region Private Methods

        private string GetTimestamp(string formatString)
        {
            return DateTime.Now.ToString(formatString);
        }

        #endregion
    }
}
