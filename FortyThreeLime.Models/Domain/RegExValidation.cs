/*************************************************************************
 * Author: DCoreyDuke
 *  * Originally from DCoreyDuke.CodeBase
 ************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FortyThreeLime.Models.Domain
{ 
    public class RegExValidation
    {

        #region Regular Expressions

        /// <summary>
        /// 12345(-6789)
        /// </summary>
        public string PostalCode_US { get; } = @"\d{5}([ \-]\d{4})?";
        /// <summary>
        /// (123)456-7890
        /// </summary>
        public string PhoneNumber { get; } = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        /// <summary>
        /// user@domain.ext
        /// </summary>
        public string EmailAddress { get; } = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        /// <summary>
        /// We begin by telling the parser to find the beginning of the string (^), followed by any lowercase letter (a-z), number (0-9), an underscore, or a hyphen. 
        /// Next, {3,16} makes sure that are at least 3 of those characters, but no more than 16. Finally, we want the end of the string ($).
        /// </summary>
        public string Username1 { get; } = @"/^[a-z0-9_-]{3,16}$/";
        /// <summary>
        /// Matching a password is very similar to matching a username. The only difference is that instead of 3 to 16 letters, numbers, underscores, or hyphens, we want 6 to 18 of them ({6,18}).
        /// </summary>
        public string Password1 { get; } = @"/^[a-z0-9_-]{6,18}$/";
        /// <summary>
        /// ex: #ffffff
        /// </summary>
        public string HexNumber { get; } = @"/^#?([a-f0-9]{6}|[a-f0-9]{3})$/";
        /// <summary>
        /// http(s)//:xxx.domain.com/xxxx
        /// </summary>
        public string URL { get; } = @"/^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$/";
        /// <summary>
        /// IP v4 Address
        /// </summary>
        public string IpAddress { get; } = @"/^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$/";

        #endregion

        #region Other Properties

        /// <summary>
        /// Regex (Syste.Text.RegularExpressions) Value of Pattern
        /// </summary>
        public Regex RegularExpression { get { return new Regex(this.Pattern); } }

        /// <summary>
        /// Regular Expression PAttern (i.e. PostalCode, EmailAddress, string regular expression pattern, etc.) 
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// The Value to Test Against the Pattern
        /// </summary>
        public string TestValue { get; set; }

        /// <summary>
        /// Test if Value matches Pattern
        /// </summary>
        /// <param name="pattern">Pattern Name</param>
        /// <param name="value">Value To Test</param>
        /// <returns>True: Value Matches Pattern | False: No Match </returns>
        public bool IsValid { get { return this.isValid(this.Pattern, TestValue); } }

        #endregion

        public RegExValidation() { }

        public RegExValidation(string pattern)
        {
            this.Pattern = pattern;
        }

        public RegExValidation(Regex pattern)
        {
            this.Pattern = pattern.ToString();
        }

        public RegExValidation(Regex pattern, string testValue)
        {
            this.Pattern = pattern.ToString();
            this.TestValue = testValue;
        }

        public RegExValidation(string pattern, string testValue)
        {
            this.Pattern = pattern;
            this.TestValue = testValue;
        }

        // Private method to Test Regex Pattern
        private bool isValid(string pattern, string value)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }



    }
}
