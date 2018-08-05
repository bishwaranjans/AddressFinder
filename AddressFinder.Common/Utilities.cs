using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AddressFinder.Common
{
    /// <summary>
    /// Utility class for implementing common functionality
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Gets the list of countries based on ISO 3166-1
        /// </summary>
        /// <returns>Returns the list of countries based on ISO 3166-1</returns>
        public static List<RegionInfo> GetCountriesByIso3166()
        {
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.SpecificCultures))
            {
                if (culture.LCID != 127 && !culture.IsNeutralCulture)
                {
                    RegionInfo country = new RegionInfo(culture.LCID);
                    if (countries.All(p => p.Name != country.Name))
                        countries.Add(country);
                }
            }
            return countries.OrderBy(p => p.EnglishName).ToList();
        }

        /// <summary>
        /// Gets the country region from it's name
        /// </summary>
        /// <param name="name">country name.</param>
        /// <returns>Returns the country region info.</returns>
        public static RegionInfo GetCountryByName(string name)
        {
            var regions = GetCountriesByIso3166();
            return regions.FirstOrDefault(region => region.EnglishName.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the country region from it's ISO code
        /// </summary>
        /// <param name="code">country ISO code.</param>
        /// <returns>Returns the list of countries by selected country codes.</returns>
        public static RegionInfo GetCountryByCode(string code)
        {
            var regions = GetCountriesByIso3166();
            var regionInfo = regions.FirstOrDefault(region => region.TwoLetterISORegionName.Contains(code, StringComparison.OrdinalIgnoreCase)) ?? regions.FirstOrDefault(region => region.ThreeLetterISORegionName.Contains(code, StringComparison.OrdinalIgnoreCase));
            return regionInfo;
        }

        /// <summary>
        /// Determines whether [is culture code] [the specified code].
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>
        ///   <c>true</c> if [is culture code] [the specified code]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCultureCode(string code)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures); //AllCultures
            int i = 0;
            while (i < cultures.Length && !cultures[i].Name.Equals(code, StringComparison.InvariantCultureIgnoreCase))
                i++;
            return i < cultures.Length;
        }

        /// <summary>
        /// Determines whether [contains] [the specified to check].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="toCheck">To check.</param>
        /// <param name="comp">The comp.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified to check]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
