using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddressFinder.Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressFinder.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressFinderController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IAddressManager _addressManager;

        public AddressFinderController(ILoggerManager logger, IAddressManager addressManager)
        {
            _logger = logger;
            _addressManager = addressManager;
        }

        // GET: api/AddressFinder
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var addressFinder = _addressManager.GetAddressFinder("CAN");
            if (addressFinder != null)
            {
                var stringAddress = @"BISHWARANJAN SANDHU\n
                             Marketing Department
                             10-123 1/2 MAIN ST SE
                             MONTREAL QC H3Z 2Y7";

                var addressDetails = addressFinder.GetAddressFromMultilineString(stringAddress);
            }
            return new string[] { "value1", "value2" };
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
