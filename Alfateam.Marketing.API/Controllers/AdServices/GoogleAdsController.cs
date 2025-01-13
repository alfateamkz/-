using Alfateam.Marketing.API.Abstractions;
using Alfateam.Marketing.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Marketing.API.Controllers.AdServices
{
    public class GoogleAdsController : AbsController
    {
        public GoogleAdsController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("Hui")]
        public async Task Hui()
        {
            var client = new Google.Ads.GoogleAds.Lib.GoogleAdsClient();
            
        }
    }
}
