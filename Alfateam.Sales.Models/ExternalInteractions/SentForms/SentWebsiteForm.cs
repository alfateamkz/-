using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.Inputs;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Values;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.SentForms
{

    public class SentWebsiteForm : AbsModel
    {
        public string UserAgent { get; set; }
        public string IP { get; set; }

        public List<SentWebsiteFormField> Fields { get; set; } = new List<SentWebsiteFormField>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int WebsiteFormExtInterationId { get; set; }
    }
}
