using System;
using System.Collections.Generic;
using System.Text;

namespace AddressFinder.Domain.SeedWork
{
    public interface IAddressFinder
    {
        /// <summary>
        /// Extracts from the supplied multiline string a dictionary
        /// of key value pairs representing the various parts of the
        /// address according to standard documentation. Keys of the
        /// IDictionary contain the names of address parts.
        /// </summary>
        IDictionary<string, string> GetAddressFromMultilineString(string address);
    }
}
