using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AddressFinder.Domain.Entities;
using AddressFinder.Domain.SeedWork;

namespace AddressFinder.Infrastructure.Repositories
{
    /// <summary>
    /// Generic address extrcator
    /// </summary>
    /// <seealso cref="AddressFinder.Domain.SeedWork.IAddressFinder" />
    public class GenericAddressFinder : IAddressFinder
    {
        #region Private members
        private readonly ILoggerManager _logger;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericAddressFinder"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public GenericAddressFinder(ILoggerManager logger)
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
        /// <exception cref="NotImplementedException"></exception>
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

                    // Second-last line  always gives information about Municipality, Provinence & PostalCode
                    var municipalityPrivinencePostalCode = addressItems.ElementAt(addressItems.Count - 2).Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(i => i).ToList();
                    foreach (var info in municipalityPrivinencePostalCode)
                    {
                        // It is a postal code information
                        if (Regex.IsMatch(info, @"^\d"))
                        {
                            addressDetails.PostalCode = info;
                            continue;
                        }

                        if (info.Length == 2) // It is the state or provinence and it is always 2 letter
                        {
                            addressDetails.Provinence = info;
                            continue;
                        }

                        if (info.Length > 2) // It is the municipality
                        {
                            addressDetails.Municipality = info;
                        }
                    }

                    #endregion

                    #region Delivery address

                    // Third-last line: Delivery address
                    var deliveryAddress = addressItems.ElementAt(addressItems.Count - 3);
                    addressDetails.RouteOrStreetAddress = deliveryAddress;

                    #endregion

                    #region Country

                    addressDetails.Country = addressItems.Last();

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
        }
        #endregion
    }
}
