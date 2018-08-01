namespace AddressFinder.Common
{
    /// <summary>
    /// Common constant file for solution
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Well known country address extractor
        /// </summary>
        public enum WellKnownAddressExtractorCountryName
        {
            /// CANADA
            CA
        }

        /// <summary>
        /// Well known address type
        /// </summary>
        public enum WellKnownAddressType
        {
            Civic,
            PostalBox,
            RuralRoute,
            GeneralDelivery,
            Unknown
        }
    }
}
