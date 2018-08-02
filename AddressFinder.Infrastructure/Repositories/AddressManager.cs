using System;
using AddressFinder.Common;
using AddressFinder.Domain.SeedWork;

namespace AddressFinder.Infrastructure.Repositories
{
    /// <summary>
    /// Address Manager
    /// </summary>
    /// <seealso cref="AddressFinder.Domain.SeedWork.IAddressManager" />
    public class AddressManager : IAddressManager
    {
        #region Private members
        private readonly ILoggerManager _logger;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressManager"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public AddressManager(ILoggerManager logger)
        {
            _logger = logger;
        }

        #region Public methods

        /// <summary>
        /// Returns an IAddressFinder based on the country name or
        /// 2- or 3-letter ISO country code
        /// </summary>
        /// <param name="countryNameOrCode"></param>
        /// <returns></returns>
        public IAddressFinder GetAddressFinder(string countryNameOrCode)
        {
            IAddressFinder addressFinder = null;

            try
            {
                // Get the country region info from it's ISO code or name
                var countryRegionInfo = Utilities.GetCountryByCode(countryNameOrCode) ?? Utilities.GetCountryByName(countryNameOrCode);
                if (countryRegionInfo == null)
                {
                    _logger.LogError($"Invalid country code or country name. Value provided {countryNameOrCode}");
                    return null;
                }

                Constants.WellKnownAddressExtractorCountryName countryName = (Constants.WellKnownAddressExtractorCountryName)Enum.Parse(typeof(Constants.WellKnownAddressExtractorCountryName), countryRegionInfo.Name);

                // Return the respective address finder as per the country
                switch (countryName)
                {
                    case Constants.WellKnownAddressExtractorCountryName.CA:
                        return new CanadianAddressFinder(_logger);
                    default:
                        return new GenericAddressFinder(_logger);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                addressFinder = new GenericAddressFinder(_logger);
            }
            return addressFinder;
        }
        #endregion
    }
}
