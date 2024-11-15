using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.CommunitationButtons;
using Alfateam.Sales.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions
{
    public class CommunitationButtonsExtInteration : ExternalInteraction
    {
        public bool IsOnlineChatEnabled { get; set; }
        public List<ContactInfo> Contacts { get; set; } = new List<ContactInfo>();



        public List<CommunitationButtonsActionsSession> ActionsSessions { get; set; } = new List<CommunitationButtonsActionsSession>();



        public override string GetSelfTypeName(string langCode = "RU")
        {
            return "Кнопки с контактами";
        }
    }
}
