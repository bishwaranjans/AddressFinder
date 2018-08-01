using System;
using System.Collections.Generic;
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
        #endregion
    }
}
