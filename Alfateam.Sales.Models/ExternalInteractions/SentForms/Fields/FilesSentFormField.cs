using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.ExternalInteractions.SentForms.Fields
{
    public class FilesSentFormField : SentWebsiteFormField
    {
        public List<FilesSentFormFieldFile> Files { get; set; } = new List<FilesSentFormFieldFile>();
    }
}
