/*************************************************************************
 * Author: DCoreyDuke
 * Originally from DCoreyDuke.CodeBase; used here for convenience
 ************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FortyThreeLime.Models.Domain
{
    public interface IAddress
    {
        string Address1 { get; set; }

        string Address2 { get; set; }

        string City { get; set; }

        string Number { get; set; }

        State State { get; set; }

        string Zip { get; set; }


    }

    [ComplexType, Serializable]
    public class Address : IAddress
    {
        private RegExValidation _ZipCodeRegExValidation;

        public Address(string address1, string address2, string number, string city, State state, string zip) : this()
        {
            this.Address1 = address1;
            this.Address2 = address2;
            this.Number = number;
            this.City = city;
            this.State = state;
            this.Zip = zip;

            this._ZipCodeRegExValidation = new RegExValidation(_ZipCodeRegExValidation.PostalCode_US, this._zip);
        }       

        private Address()
        {
        }

        [Required(ErrorMessage = "Address is required"), StringLength(256, MinimumLength = 1, ErrorMessage = "Address MUST be between 1 and 256 chars.")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required(ErrorMessage = "City is Required"), StringLength(128, MinimumLength = 1, ErrorMessage = "City MUST be between 1 and 128 chars")]
        public string City { get; set; }

        public string Number { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public State State { get; set; }

        private string _zip;
        [Required(ErrorMessage = "Zip Code is Required"), StringLength(5, MinimumLength = 5, ErrorMessage = "Zip Code MUST contain 5 digits"), RegularExpression(@"^\d{5}$", ErrorMessage = "Zip Code MUST contain 5 numbers!")]
        public string Zip {
            get
            {
                if(_ZipCodeRegExValidation.IsValid)
                {
                    return this._zip;
                }
                else
                {
                    throw new ArgumentException("Zip is Invalid!");
                }
            }
            set
            {
                if (_ZipCodeRegExValidation.IsValid)
                {
                    this._zip = value;
                }
                else
                {
                    throw new ArgumentException("Zip is Invalid!");
                }
            }
        }
    }

 
}
