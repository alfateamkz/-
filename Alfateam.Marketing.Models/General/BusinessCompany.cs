using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using Alfateam.Marketing.Models.Ads;
using Alfateam.Marketing.Models.Segments;
using Alfateam.Marketing.Models.Templates;
using Alfateam.SharedModels.Abstractions.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.General
{
    public class BusinessCompany : AbsModel
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string? LogoPath { get; set; }





        public List<User> Users { get; set; } = new List<User>();
        public Department Department { get; set; }



        public List<AdsTask> AdsTasks { get; set; } = new List<AdsTask>();
        public List<AdsServiceAccount> AdsServiceAccounts { get; set; } = new List<AdsServiceAccount>();


        public List<ExternalInteraction> ExternalInteractions { get; set; } = new List<ExternalInteraction>();
        public List<ReferralProgram> ReferralPrograms { get; set; } = new List<ReferralProgram>();




        public List<Segment> Segments { get; set; } = new List<Segment>();
        public List<LetteringCampaign> LetteringCampaigns { get; set; } = new List<LetteringCampaign>();
        public List<SalesGenerator> SalesGenerators { get; set; } = new List<SalesGenerator>();





        public List<MailingAccount> MailingAccounts { get; set; } = new List<MailingAccount>();
        public List<SMSGatewaySettings> SMSGateways { get; set; } = new List<SMSGatewaySettings>();
        public List<Template> Templates { get; set; } = new List<Template>();



        public List<MarketingContact> MarketingContacts { get; set; } = new List<MarketingContact>();
        public List<BlacklistItem> BlacklistItems { get; set; } = new List<BlacklistItem>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}
