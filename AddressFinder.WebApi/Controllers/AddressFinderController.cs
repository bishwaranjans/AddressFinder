using System.Collections.Generic;
using AddressFinder.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;

namespace AddressFinder.WebApi.Controllers
{
    /// <summary>
    /// Address Finder controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AddressFinderController : ControllerBase
    {
        #region Private members
        private readonly ILoggerManager _logger;
        private readonly IAddressManager _addressManager;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressFinderController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="addressManager">The address manager.</param>
        public AddressFinderController(ILoggerManager logger, IAddressManager addressManager)
        {
            _logger = logger;
            _addressManager = addressManager;
        }

        // GET: api/AddressFinder
        [HttpGet]
        public IDictionary<string, string> Get()
        {
            var addressFinder = _addressManager.GetAddressFinder("CAN");
            if (addressFinder != null)
            {
                var stringAddress = @"BISHWARANJAN SANDHU
                             Marketing Department
                             10-123 1/2 MAIN ST SE
                             MONTREAL QC   H3Z 2Y7";

                var addressDetails = addressFinder.GetAddressFromMultilineString(stringAddress);
                return addressDetails;
            }
            return null;
        }

        // GET: api/AddressFinder/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AddressFinder
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AddressFinder/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
