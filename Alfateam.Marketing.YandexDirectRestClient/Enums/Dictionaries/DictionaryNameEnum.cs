using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries
{
    public enum DictionaryNameEnum
    {
        [Description("Currencies")]
        Currencies = 1,
        [Description("MetroStations")]
        MetroStations = 2,
        [Description("GeoRegions")]
        GeoRegions = 3,
        [Description("GeoRegionNames")]
        GeoRegionNames = 4,
        [Description("TimeZones")]
        TimeZones = 5,
        [Description("Constants")]
        Constants = 6,
        [Description("AdCategories")]
        AdCategories = 7,
        [Description("OperationSystemVersions")]
        OperationSystemVersions = 8,
        [Description("ProductivityAssertions")]
        ProductivityAssertions = 9,
        [Description("SupplySidePlatforms")]
        SupplySidePlatforms = 10,
        [Description("Interests")]
        Interests = 11,
        [Description("AudienceCriteriaTypes")]
        AudienceCriteriaTypes = 12,
        [Description("AudienceDemographicProfiles")]
        AudienceDemographicProfiles = 13,
        [Description("AudienceInterests")]
        AudienceInterests = 14,
        [Description("FilterSchemas")]
        FilterSchemas = 15,
    }
}
