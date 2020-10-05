/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Models.Domain;
using System;
using System.Text.RegularExpressions;

namespace FortyThreeLime.Web.Services
{
    /// <summary>
    /// Address Data Service -  gets Address information for the application
    /// Queries Google Maps Services for certain data ops
    /// </summary>
    internal sealed class AddressService : IDataService
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets the geo coded address.
        /// </summary>
        /// <value>
        /// The geo coded address.
        /// </value>
        public GeoCodeResponseObject GeoCodedAddress => GetGeoCodedAddress(Address);

        private AddressService()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressService"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public AddressService(Address address) : this()
        {
            this.Address = address;
        }

        /// <summary>
        /// Gets the geo coded address.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        private GeoCodeResponseObject GetGeoCodedAddress(Address address)
        {
            string str = address.Address1 + " " + 
                         address.Address2 + " " + 
                         address.Number + " " + 
                         address.City + " " +  
                         address.State.ToString() + " "  +
                         address.Zip;
            return GetGeoCodedAddress(str);
        }

        /// <summary>
        /// Get GeoCoded Address From Google
        /// </summary>
        private GeoCodeResponseObject GetGeoCodedAddress(string address)
        {
            if (!string.IsNullOrEmpty(address))
            {
                // Replace any White Space (i.e. Tabs, NewLines, etc 
                // Regular Expression \s is equivalent to  [  \f\n\r\t\v]
                address = Regex.Replace(address, @"(\s)\s+", " ");

                //TODO: Create WebRequest To Google GeoCoding API

                //TODO: Create GeoCodeResponseObject from returned JSON
            }
            else
            {
                throw new ArgumentException("Address Must Be Provided!");
            }

            return new GeoCodeResponseObject();
        }
    }

    /// <summary>
    /// Container For Json Data Returned From Google Api
    /// </summary>
    public sealed class GeoCodeResponseObject
    {
        /* Google GeoCode API JSON Result Format
         * https://maps.googleapis.com/maps/api/geocode/json?address=<number>+<street>,+M<city>,+CA&key=YOUR_API_KEY (spaces replaced w/ +)

         * {
         * "results" : [
         *       {
         *          "address_components" : [
         *             {
         *                "long_name" : "1600",
         *                "short_name" : "1600",
         *                "types" : [ "street_number" ]
         *             },
         *             {
         *                "long_name" : "Amphitheatre Parkway",
         *                "short_name" : "Amphitheatre Pkwy",
         *                "types" : [ "route" ]
         *             },
         *             {
         *                "long_name" : "Mountain View",
         *                "short_name" : "Mountain View",
         *                "types" : [ "locality", "political" ]
         *             },
         *             {
         *                "long_name" : "Santa Clara County",
         *                "short_name" : "Santa Clara County",
         *                "types" : [ "administrative_area_level_2", "political" ]
         *             },
         *             {
         *                "long_name" : "California",
         *                "short_name" : "CA",
         *                "types" : [ "administrative_area_level_1", "political" ]
         *             },
         *             {
         *                "long_name" : "United States",
         *                "short_name" : "US",
         *                "types" : [ "country", "political" ]
         *             },
         *             {
         *                "long_name" : "94043",
         *                "short_name" : "94043",
         *                "types" : [ "postal_code" ]
         *             }
         *          ],
         *          "formatted_address" : "1600 Amphitheatre Pkwy, Mountain View, CA 94043, USA",
         *          "geometry" : {
         *             "location" : {
         *                "lat" : 37.4267861,
         *                "lng" : -122.0806032
         *             },
         *             "location_type" : "ROOFTOP",
         *             "viewport" : {
         *                "northeast" : {
         *                   "lat" : 37.4281350802915,
         *                   "lng" : -122.0792542197085
         *                },
         *                "southwest" : {
         *                   "lat" : 37.4254371197085,
         *                   "lng" : -122.0819521802915
         *                }
         *             }
         *          },
         *          "place_id" : "ChIJtYuu0V25j4ARwu5e4wwRYgE",
         *          "plus_code" : {
         *             "compound_code" : "CWC8+R3 Mountain View, California, United States",
         *             "global_code" : "849VCWC8+R3"
         *          },
         *          "types" : [ "street_address" ]
         *       }
         *     ,
         *     status" : "OK"
         *   }   
         */

    }

}