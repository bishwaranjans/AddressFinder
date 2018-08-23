using System;
using System.Collections.Generic;
using System.Text;
using AddressFinder.Domain.SeedWork;
using AddressFinder.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AddressFinder.Tests
{
    [TestClass]
    public class CanadianAddressFinderTest
    {
        private readonly CanadianAddressFinder _canadianAddressFinder;

        public CanadianAddressFinderTest()
        {
            ILoggerManager logger = new LoggerManager();
            _canadianAddressFinder = new CanadianAddressFinder(logger);
        }

        [TestMethod]
        public void GetAddresseeNameFromMultilineStringTest()
        {
            var stringAddress = @"BISHWARANJAN SANDHU
                             Marketing Department
                             10-123 1/2 MAIN ST SE
                             MONTREAL QC   H3Z 2Y7";

            var addressDetails = _canadianAddressFinder.GetAddressFromMultilineString(stringAddress);

            Assert.AreEqual("BISHWARANJAN SANDHU", addressDetails["Addressee"]);
        }

        [TestMethod]
        public void GetPostalCodeFromMultilineStringTest()
        {
            var stringAddress = @"BISHWARANJAN SANDHU
                             Marketing Department
                             10-123 1/2 MAIN ST SE
                             MONTREAL QC   H3Z 2Y7";

            var addressDetails = _canadianAddressFinder.GetAddressFromMultilineString(stringAddress);

            Assert.AreEqual("H3Z 2Y7", addressDetails["PostalCode"]);
        }

        [TestMethod]
        public void GetMunicipalityFromMultilineStringTest()
        {
            var stringAddress = @"BISHWARANJAN SANDHU
                             Marketing Department
                             10-123 1/2 MAIN ST SE
                             MONTREAL QC   H3Z 2Y7";

            var addressDetails = _canadianAddressFinder.GetAddressFromMultilineString(stringAddress);

            Assert.AreEqual("MONTREAL", addressDetails["Municipality"]);
        }
    }
}
