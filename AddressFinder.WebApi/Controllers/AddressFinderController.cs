using System.Collections.Generic;
using System.Net.Http;
using AddressFinder.Domain.SeedWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;

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
        public Dictionary<string, IDictionary<string, string>> Get()
        {
            var testAddress = new Dictionary<string, IDictionary<string, string>>();

            // Well known canadaian address
            var canadaianAddressFinder = _addressManager.GetAddressFinder("CAN");
            if (canadaianAddressFinder != null)
            {
                var stringAddress = @"BISHWARANJAN SANDHU
                             Marketing Department
                             10-123 1/2 MAIN ST SE
                             MONTREAL QC   H3Z 2Y7";

                var addressDetails = canadaianAddressFinder.GetAddressFromMultilineString(stringAddress);
                testAddress.Add("CAN", addressDetails);
            }
            else
            {
                throw new HttpRequestException("Please provide a valid country code or country name.");
            }

            // NETHERLANDS address
            var generalAddressFinder1 = _addressManager.GetAddressFinder("NETHERLANDS");
            if (generalAddressFinder1 != null)
            {
                var stringAddress = @"JOHN JONES
                             ROTERDAM 7B
                             3053  ES ROTTERDAM
                             NETHERLANDS";

                var addressDetails = generalAddressFinder1.GetAddressFromMultilineString(stringAddress);
                testAddress.Add("NETHERLANDS", addressDetails);
            }
            else
            {
                throw new HttpRequestException("Please provide a valid country code or country name.");
            }

            // USA
            var generalAddressFinder2 = _addressManager.GetAddressFinder("USA");
            if (generalAddressFinder2 != null)
            {
                var stringAddress = @"JOHN JONES
                             101 W MAIN ST S APT 101
                             WASHINGTON DC 20019-4649
                             USA";

                var addressDetails = generalAddressFinder2.GetAddressFromMultilineString(stringAddress);
                testAddress.Add("USA", addressDetails);
            }
            else
            {
                throw new HttpRequestException("Please provide a valid country code or country name.");
            }

            return testAddress;
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
