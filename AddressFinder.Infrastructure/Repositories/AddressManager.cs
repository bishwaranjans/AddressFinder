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
        public IAddressFinder GetAddressFinder(string countryNameOrCode)
        {
            IAddressFinder addressFinder = null;
            RegionInfo countryRegionInfo;

            // Get the country region info from it's ISO code or name
            countryRegionInfo = Utilities.IsCultureCode(countryNameOrCode) ? Utilities.GetCountryByCode(countryNameOrCode) : Utilities.GetCountryByName(countryNameOrCode);

            return addressFinder;
        }
    }
}
