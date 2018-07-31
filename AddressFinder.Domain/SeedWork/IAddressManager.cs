using System;
using System.Collections.Generic;
using System.Text;

namespace AddressFinder.Domain.SeedWork
{
    public interface IAddressManager
    {
        /// <summary>
        /// Returns an IAddressFinder based on the country name or
        /// 2- or 3-letter ISO country code
        /// </summary>
        IAddressFinder GetAddressFinder(string countryNameOrCode);
    }
}
