using System;
using System.Collections.Generic;
using System.Text;
using AddressFinder.Domain.SeedWork;

namespace AddressFinder.Infrastructure.Repositories
{
    public class GenericAddressFinder : IAddressFinder
    {
        public IDictionary<string, string> GetAddressFromMultilineString(string address)
        {
            throw new NotImplementedException();
        }
    }
}
