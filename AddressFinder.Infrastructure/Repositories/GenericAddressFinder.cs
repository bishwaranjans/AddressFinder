using System;
using System.Collections.Generic;
using System.Text;
using AddressFinder.Domain.SeedWork;

namespace AddressFinder.Infrastructure.Repositories
{
    public class GenericAddressFinder : IAddressFinder
    {
        private readonly ILoggerManager _logger;

        public GenericAddressFinder(ILoggerManager logger)
        {
            _logger = logger;
        }

        public IDictionary<string, string> GetAddressFromMultilineString(string address)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
