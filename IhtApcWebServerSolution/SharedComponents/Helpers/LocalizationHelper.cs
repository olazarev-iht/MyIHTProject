using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SharedComponents.Helpers
{
    public class LocalizationHelper
    {
        public static string? GetRegionNameFromCulture(CultureInfo? cultureInfo)
        {
            var regionName = cultureInfo?.Name.Split("-")[1] ?? null;
            regionName = regionName == "Hans" ? "CN" : regionName;

            return regionName;
        }

        public static string? GetFlagNameFromRegionName(string regionName)
        {
            var regionInfo = new RegionInfo(regionName);
            var flagName = regionInfo.TwoLetterISORegionName.ToLower() + ".gif";

            return flagName;
        }

        public static string GetFlagNamePath(string flagName)
        {
            return $"Images/Culture/IsoNames/{@flagName}";
        }

        public static string GetLanguageEnglishName(CultureInfo? cultureInfo)
        {
            var languageName = cultureInfo?.EnglishName.Split(" ")[0] ?? string.Empty;

            return languageName;
        }

    }
}
