using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using GoogleTrends;
using GoogleTrends.Models;
using GoogleTrends.Models.AutoComplete;
using GoogleTrends.Models.Explore;
using GoogleTrends.Models.Explore.Request;
using GoogleTrends.Models.GeoData;
using GoogleTrends.Models.ParameterTypes;
using GoogleTrends.Models.RealtimeTrends;
using GoogleTrends.Models.RealtimeTrends.Request;
using GoogleTrends.Models.Widgets;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Marketing.API.Controllers.Integrations.SEO
{
    public class GoogleTrendsIntegrationController : AbsController
    {
        public GoogleTrendsIntegrationController(ControllerParams @params) : base(@params)
        {
            
        }

        [HttpGet, Route("GetAutoCompleteSuggestions")]
        public async Task<AutoCompleteSuggestion[]> GetAutoCompleteSuggestions(string query)
        {
            return await new GoogleTrendsClient().AutoComplete.GetAutoCompleteSuggestions(query);
        }

        [HttpGet, Route("GetAutoCompleteSuggestionsFiltered")]
        public async Task<AutoCompleteSuggestion[]> GetAutoCompleteSuggestionsFiltered(string query, [FromQuery]ApiParameter model)
        {
            return await new GoogleTrendsClient().AutoComplete.GetAutoCompleteSuggestions(model, query);
        }




        [HttpGet, Route("GetGeoDataWidget")]
        public async Task<GeoMapData[]> GetGeoDataWidget([FromQuery] Widget model)
        {
            return await new GoogleTrendsClient().Widgets.GetGeoDataWidget(model);
        }

        [HttpGet, Route("GetGeoDataWidgetFiltered")]
        public async Task<GeoMapData[]> GetGeoDataWidgetFiltered([FromQuery] WidgetRequestParameter relatedQueryParameters)
        {
            return await new GoogleTrendsClient().Widgets.GetGeoDataWidget(relatedQueryParameters);
        }

    




        [HttpGet, Route("GetTimelineWidget")]
        public async Task<TimelineData[]> GetTimelineWidget([FromQuery] Widget model)
        {
            return await new GoogleTrendsClient().Widgets.GetTimelineWidget(model);
        }
        [HttpGet, Route("GetTimelineWidgetFiltered")]
        public async Task<TimelineData[]> GetTimelineWidgetFiltered([FromQuery] WidgetRequestParameter relatedQueryParameters)
        {
            return await new GoogleTrendsClient().Widgets.GetTimelineWidget(relatedQueryParameters);
        }



        [HttpGet, Route("GetRelatedQueriesWidget")]
        public async Task<RankedList[]> GetRelatedQueriesWidget([FromQuery] Widget model)
        {
            return await new GoogleTrendsClient().Widgets.GetRelatedQueriesWidget(model);
        }

        [HttpGet, Route("GetRelatedQueriesWidgetFiltered")]
        public async Task<RankedList[]> GetRelatedQueriesWidgetFiltered([FromQuery] WidgetRequestParameter relatedQueryParameters)
        {
            return await new GoogleTrendsClient().Widgets.GetRelatedQueriesWidget(relatedQueryParameters);
        }



        [HttpGet, Route("GetDailyTrends")]
        public async Task<DailyTrends> GetDailyTrends()
        {
            return await new GoogleTrendsClient().RealtimeTrends.GetDailyTrends();
        }

        [HttpGet, Route("GetDailyTrendsFiltered")]
        public async Task<DailyTrends> GetDailyTrendsFiltered(DailyTrendsParameters dailyTrendsParameters)
        {
            return await new GoogleTrendsClient().RealtimeTrends.GetDailyTrends(dailyTrendsParameters);
        }




        [HttpGet, Route("GetRealtimeTrends")]
        public async Task<RealTimeTrends> GetRealtimeTrends()
        {
            return await new GoogleTrendsClient().RealtimeTrends.GetRealtimeTrends();
        }

        [HttpGet, Route("GetRealtimeTrendsFiltered")]
        public async Task<RealTimeTrends> GetRealtimeTrendsFiltered(RealTimeTrendsParameters realTimeTrendsParameters)
        {
            return await new GoogleTrendsClient().RealtimeTrends.GetRealtimeTrends(realTimeTrendsParameters);
        }




        [HttpGet, Route("GetAllGeoLocations")]
        public async Task<GeoLocation> GetAllGeoLocations()
        {
            return await new GoogleTrendsClient().GeoLocation.GetAllGeoLocations();
        }

        [HttpGet, Route("GetAllGeoLocationsFiltered")]
        public async Task<GeoLocation> GetAllGeoLocationsFiltered([FromQuery] ApiParameter parameter)
        {
            return await new GoogleTrendsClient().GeoLocation.GetAllGeoLocations(parameter);
        }






        [HttpGet, Route("ExploreQuery")]
        public async Task<ExploreResponse> ExploreQuery(ExploreQueryParameters exploreQueryParameters)
        {
            return await new GoogleTrendsClient().Explore.ExploreQuery(exploreQueryParameters);
        }

        [HttpGet, Route("ExploreQueryFiltered")]
        public async Task<ExploreResponse> ExploreQueryFiltered(string query, 
                                                               SearchType searchType = SearchType.WebSearch, 
                                                               UserRegion userRegion = UserRegion.UnitedStates, 
                                                               QueryTimes queryTime = QueryTimes.PastDay, 
                                                               GeoId geoSearch = GeoId.WorldWide)
        {
            return await new GoogleTrendsClient().Explore.ExploreQuery(query, searchType, userRegion, queryTime, geoSearch);
        }
    }
}
