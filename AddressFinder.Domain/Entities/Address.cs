using AddressFinder.Common;

namespace AddressFinder.Domain.Entities
{
    /// <summary>
    /// Entity Address
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the addressee.
        /// </summary>
        /// <value>
        /// The addressee.
        /// </value>
        public string Addressee { get; set; }

        /// <summary>
        /// Gets or sets the delivery information.
        /// </summary>
        /// <value>
        /// The delivery information.
        /// </value>
        public string DeliveryInformation { get; set; }

        /// <summary>
        /// Gets or sets the route or street identifier.
        /// </summary>
        /// <value>
        /// The route or street identifier.
        /// </value>
        public string RouteOrStreetIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the municipality.
        /// </summary>
        /// <value>
        /// The municipality.
        /// </value>
        public string Municipality { get; set; }

        /// <summary>
        /// Gets or sets the provinence.
        /// </summary>
        /// <value>
        /// The provinence.
        /// </value>
        public string Provinence { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the type of the address.
        /// </summary>
        /// <value>
        /// The type of the address.
        /// </value>
        public Constants.WellKnownAddressType AddressType { get; set; }
    }
}
