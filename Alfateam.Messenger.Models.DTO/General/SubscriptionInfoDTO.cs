using Alfateam.Core.Attributes.DTO;
using Alfateam.Messenger.Models.General;
using Alfateam.Website.API.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.DTO.General
{
    public class SubscriptionInfoDTO : DTOModelAbs<SubscriptionInfo>
    {
        [ForClientOnly]
        public bool CanUseFeedbackForms { get; set; }
        [ForClientOnly]
        public bool CanUseExternalChats { get; set; }


        [ForClientOnly]
        public int AllowedAccountsCount { get; set; }
        [ForClientOnly]
        public DateTime SubscriptionBefore { get; set; }
    }
}
