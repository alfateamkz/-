using Alfateam.Marketing.Models.Enums.SEO.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Attributes
{
    public class SEOErrorSeverityTypeAttribute : Attribute
    {
        public readonly SEOErrorSeverity Severity;
        public SEOErrorSeverityTypeAttribute(SEOErrorSeverity severity)
        {
            Severity = severity;
        }
    }
}
