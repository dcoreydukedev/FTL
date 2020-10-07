/*************************************************************************
 * Author: DCoreyDuke
 * Description: Provides Geocoding Services to the Solution
 * References: https://github.com/chadly/Geocoding.net
 ************************************************************************/

using Geocoding;

namespace FortyThreeLime.API.Services.Data
{
    /// <summary>
    /// Address Data Service -  gets Address information for the application
    /// Queries Google Maps Services for certain data ops
    /// </summary>
    internal sealed class GeocodingService : IDataService
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address { get; set; }

       
        private GeocodingService()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeocodingService"/> class.
        /// </summary>
        /// <param name="address">The address.</param>
        public GeocodingService(Address address) : this()
        {
            this.Address = address;
        }

        

        
    }

   

}