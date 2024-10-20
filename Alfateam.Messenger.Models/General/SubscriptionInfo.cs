using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Models.General
{
    public class SubscriptionInfo : AbsModel
    {
        public bool CanUseFeedbackForms { get; set; }
        public bool CanUseExternalChats { get; set; }


        public int AllowedAccountsCount { get; set; } = 5;
        public DateTime SubscriptionBefore { get; set; }
    }
}
