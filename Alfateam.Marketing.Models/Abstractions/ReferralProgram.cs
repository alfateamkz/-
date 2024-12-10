using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.Models.Referral.Main;
using Alfateam.Marketing.Models.Ads.Accounts;
using JsonKnownTypes;
using Alfateam.Marketing.Models.Referral;
using Newtonsoft.Json;

namespace Alfateam.Marketing.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ReferralProgram>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(MLMNetworkReferralProgram), "MLMNetworkReferralProgram")]
    [JsonKnownType(typeof(MultiLevelReferralProgram), "MultiLevelReferralProgram")]
    [JsonKnownType(typeof(SimpleReferralProgram), "SimpleReferralProgram")]
    public class ReferralProgram : AbsModel
    {
        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public string Title { get; set; }
        public string? Description { get; set; }


        public List<ReferralUser> Referrals { get; set; } = new List<ReferralUser>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
