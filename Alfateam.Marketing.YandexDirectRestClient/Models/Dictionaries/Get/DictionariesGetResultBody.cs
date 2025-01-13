using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class DictionariesGetResultBody
    {
        [JsonProperty("Currencies")]
        public List<CurrenciesItem> Currencies { get; set; } = new List<CurrenciesItem>();

        [JsonProperty("MetroStations")]
        public List<MetroStationsItem> MetroStations { get; set; } = new List<MetroStationsItem>();

        [JsonProperty("GeoRegions")]
        public List<GeoRegionsItem> GeoRegions { get; set; } = new List<GeoRegionsItem>();

        [JsonProperty("GeoRegionNames")]
        public List<GeoRegionNamesItem> GeoRegionNames { get; set; } = new List<GeoRegionNamesItem>();

        [JsonProperty("TimeZones")]
        public List<TimeZonesItem> TimeZones { get; set; } = new List<TimeZonesItem>();

        [JsonProperty("Constants")]
        public List<ConstantsItem> Constants { get; set; } = new List<ConstantsItem>();

        [JsonProperty("AdCategories")]
        public List<AdCategoriesItem> AdCategories { get; set; } = new List<AdCategoriesItem>();

        [JsonProperty("OperationSystemVersions")]
        public List<OperationSystemVersionsItem> OperationSystemVersions { get; set; } = new List<OperationSystemVersionsItem>();

        [JsonProperty("SupplySidePlatforms")]
        public List<SupplySidePlatformsItem> SupplySidePlatforms { get; set; } = new List<SupplySidePlatformsItem>();

        [JsonProperty("Interests")]
        public List<InterestsItem> Interests { get; set; } = new List<InterestsItem>();

        [JsonProperty("AudienceCriteriaTypes")]
        public List<AudienceCriteriaTypesItem> AudienceCriteriaTypes { get; set; } = new List<AudienceCriteriaTypesItem>();

        [JsonProperty("AudienceDemographicProfiles")]
        public List<AudienceDemographicProfilesItem> AudienceDemographicProfiles { get; set; } = new List<AudienceDemographicProfilesItem>();

        [JsonProperty("AudienceInterests")]
        public List<AudienceInterestsItem> AudienceInterests { get; set; } = new List<AudienceInterestsItem>();

        [JsonProperty("FilterSchemas")]
        public List<FilterSchemasItem> FilterSchemas { get; set; } = new List<FilterSchemasItem>();
    }
}
