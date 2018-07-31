using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AddressFinder.Common
{
    public static class Utilities
    {
        /// <summary>
        /// Gets the list of countries based on ISO 3166-1
        /// </summary>
        /// <returns>Returns the list of countries based on ISO 3166-1</returns>
        public static List<RegionInfo> GetCountriesByIso3166()
        {
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo country = new RegionInfo(culture.LCID);
                if (countries.All(p => p.Name != country.Name))
                    countries.Add(country);
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
            var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));
            return regions.FirstOrDefault(region => region.EnglishName.Contains(name));
        }

        /// <summary>
        /// Gets the country region from it's ISO code
        /// </summary>
        /// <param name="code">country ISO code.</param>
        /// <returns>Returns the list of countries by selected country codes.</returns>
        public static RegionInfo GetCountryByCode(string code)
        {
            var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID)).ToList();
            var regionInfo = regions.FirstOrDefault(region => region.TwoLetterISORegionName.Contains(code)) ?? regions.FirstOrDefault(region => region.ThreeLetterISORegionName.Contains(code));

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
    }
}
