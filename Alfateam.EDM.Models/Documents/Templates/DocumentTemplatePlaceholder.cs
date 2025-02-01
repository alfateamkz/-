using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Core;

namespace Alfateam.EDM.Models.Documents.Templates
{
    public class DocumentTemplatePlaceholder : AbsModel
    {
        public string Title { get; set; }
        public string Placeholder { get; set; }
        public bool IsRequired { get; set; }
    }
}
