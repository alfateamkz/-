﻿using Alfateam.Marketing.Models.Referral.Items;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Marketing.API.Models.DTO.Referral.Items
{
    public class MLMNetworkReferralProgramLevelDTO : DTOModelAbs<MLMNetworkReferralProgramLevel>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public double Percent { get; set; }
    }
}
