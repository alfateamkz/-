using Alfateam.Marketing.Models.Abstractions;
using Alfateam.SharedModels.Abstractions.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Lettering
{
    public class SMSLetteringCampaign : LetteringCampaign
    {
        public SMSGatewaySettings Gateway { get; set; }
    }
}
