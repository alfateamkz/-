using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.Inputs
{
    public class TextWebsiteFormInput : WebsiteFormInput
    {
        public bool Multiline { get; set; }
        public int? MaxLength { get; set; }
        public int? MinLength { get; set; }
    }
}
