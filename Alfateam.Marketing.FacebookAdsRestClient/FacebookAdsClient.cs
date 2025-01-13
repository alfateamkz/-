using FacebookAds.Object;

namespace Alfateam.Marketing.FacebookAdsRestClient
{
    public class FacebookAdsClient
    {
        public FacebookAdsClient()
        {
            var client = new Facebook.FacebookClient("accessToken");
            client.Get("","");

            new AdAccount("1").GetCustomAudiencesTos();

        }

    }
}
