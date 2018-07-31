using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using AddressFinder.Common;
using AddressFinder.Domain.SeedWork;

namespace AddressFinder.Infrastructure.Repositories
{
    public class AddressManager : IAddressManager
    {
        private readonly ILoggerManager _logger;

        public AddressManager(ILoggerManager logger)
        {
            _logger = logger;
        }

        public IAddressFinder GetAddressFinder(string countryNameOrCode)
        {
            IAddressFinder addressFinder = null;

            try
            {
                // Get the country region info from it's ISO code or name
                var countryRegionInfo = Utilities.GetCountryByCode(countryNameOrCode) ?? Utilities.GetCountryByName(countryNameOrCode);
                if (countryRegionInfo == null)
                {
                    _logger.LogError("Invalid country code or country name.");
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
    }
}
