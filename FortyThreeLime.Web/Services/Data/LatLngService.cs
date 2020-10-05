/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using FortyThreeLime.Models.Entities;
using FortyThreeLime.Models.Domain;

namespace FortyThreeLime.Web.Services.Data
{
    /// <summary>
    /// LatLng Data Service -  gets Latitude and Longitude information for the application
    /// Queries Google Maps Services for certain data ops
    /// </summary>
    internal sealed class LatLngService : IDataService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the lat LNG.
        /// </summary>
        /// <value>
        /// The lat LNG.
        /// </value>
        public LatLng LatLng { get; set; }
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public string Latitude { get; set; }
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public string Longitude { get; set; }

        #endregion

        private LatLngService()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LatLngService"/> class.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public LatLngService(string latitude, string longitude) : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.LatLng = new LatLng(latitude, longitude);
        }

    }   

}