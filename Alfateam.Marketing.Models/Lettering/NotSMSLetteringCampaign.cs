using Alfateam.Marketing.Models.Abstractions;
using Alfateam.Marketing.Models.Abstractions.MailingAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Lettering
{
    public class NotSMSLetteringCampaign : LetteringCampaign
    {
        public MailingAccount Account { get; set; }
    }
}
