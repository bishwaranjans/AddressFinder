using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AddressFinder.Common;
using AddressFinder.Domain.Entities;
using AddressFinder.Domain.SeedWork;

namespace AddressFinder.Infrastructure.Repositories
{
    /// <summary>
    /// Canadian address extrcator
    /// </summary>
    /// <seealso cref="AddressFinder.Domain.SeedWork.IAddressFinder" />
    public class CanadianAddressFinder : IAddressFinder
    {
        #region Private members
        private readonly ILoggerManager _logger;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CanadianAddressFinder"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public CanadianAddressFinder(ILoggerManager logger)
        {
            _logger = logger;
        }

        #region Public methods

        /// <summary>
        /// Extracts from the supplied multiline string a dictionary
        /// of key value pairs representing the various parts of the
        /// address according to standard documentation. Keys of the
        /// IDictionary contain the names of address parts.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public IDictionary<string, string> GetAddressFromMultilineString(string address)
        {
            var dicAddressInformation = new Dictionary<string, string>();

            try
            {
                var addressItems = address.Split(Environment.NewLine).Select(i => i).ToList();

                var addressDetails = new Address();

                if (addressItems.Any())
                {
                    #region Addressee
                    // The firstline is always the addressee
                    addressDetails.Addressee = addressItems.First();
                    #endregion

                    #region Municipality, Provinence & PostalCode
                    // The last line is always Municipality Name, Province or Territory and Postal Code
                    var addressLastLineList = addressItems.Last().Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(i => i).ToList();
                    addressDetails.Municipality = addressLastLineList.First(); // First item is municipality
                    addressDetails.Provinence = addressLastLineList[1]; // Secomd items is provinence
                    addressDetails.PostalCode = string.Join(" ", addressLastLineList.Where((v, i) => i != 0 && i != 1).ToList());
                    #endregion

                    #region Address Type
                    var addressTypeLine = addressItems.ElementAt(addressItems.Count - 2); // Second-last line  always gives information about address type

                    // Should use the two-letter symbol RR followed by the route number placed one space to the right.
                    Regex ruralRouteIdentifierRegex = new Regex(@"^[RR ]\d$");

                    // Should start with GD
                    Regex generalDeliveryIdentifierRegex = new Regex(@"^[GD ]$");

                    // Address type
                    if (addressTypeLine.Contains("PO BOX"))
                    {
                        addressDetails.AddressType = Constants.WellKnownAddressType.PostalBox;
                    }
                    else if (ruralRouteIdentifierRegex.IsMatch(addressTypeLine)) // Check for rural route
                    {
                        addressDetails.AddressType = Constants.WellKnownAddressType.RuralRoute;
                    }
                    else if (addressTypeLine.Contains("ST")) // Check for Civil
                    {
                        addressDetails.AddressType = Constants.WellKnownAddressType.Civic;
                    }
                    else if (generalDeliveryIdentifierRegex.IsMatch(addressTypeLine)) // Check for general delivery.
                    {
                        addressDetails.AddressType = Constants.WellKnownAddressType.GeneralDelivery;
                    }
                    else
                    {
                        addressDetails.AddressType = Constants.WellKnownAddressType.Unknown;
                    }
                    addressDetails.RouteOrStreetAddress = addressTypeLine;

                    #endregion

                    #region Country
                    addressDetails.Country = "CANADA";
                    #endregion

                    PropertyInfo[] properties = typeof(Address).GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        if (property != null)
                        {
                            dicAddressInformation.Add(property.Name, property.GetValue(addressDetails) == null ? null : property.GetValue(addressDetails).ToString().Trim());
                        }
                    }

                    return dicAddressInformation;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return dicAddressInformation;

            #endregion
        }
    }
}
