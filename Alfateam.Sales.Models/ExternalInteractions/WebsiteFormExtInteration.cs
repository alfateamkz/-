using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Enums;
using Alfateam.Sales.Models.ExternalInteractions.SentForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions
{
    public class WebsiteFormExtInteration : ExternalInteraction
    {
        public string Header { get; set; }
        public string? Description { get; set; }
        public WebsiteFormType Type { get; set; }


        public List<WebsiteFormInput> Inputs { get; set; } = new List<WebsiteFormInput>();


        public string? PrivacyPolicyURL { get; set; }




        public List<SentWebsiteForm> SentWebsiteForms { get; set; } = new List<SentWebsiteForm>();


        public override string GetSelfTypeName(string langCode = "RU")
        {
            return "Форма обратной связи";
        }
    }
}
