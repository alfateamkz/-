using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.BusinessAssetSharingAgreements
{
    public class BusinessAssetSharingAgreement
    {
        [JsonProperty("custom_audiences")]
        public List<BusinessAssetSharingAgreementSharedAudienceResponseShape> CustomAudiences { get; set; } = new List<BusinessAssetSharingAgreementSharedAudienceResponseShape>();
    }
}
