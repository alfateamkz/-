using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Documents.Templates
{
    public class DocumentTemplate
    {
        public string Title { get; set; }
        public Document Document { get; set; }
        public List<DocumentTemplatePlaceholder> Placeholders { get; set; } = new List<DocumentTemplatePlaceholder>();
    }
}
