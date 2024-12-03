using Alfateam.Core;
using Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts.Props;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Websites.SEO.SiteInfoParser.Parts
{
    public class SiteInfoParserSchemaMarkupValidator : AbsModel
    {
        public List<SchemaMarkupValidatorMicromarkupItem> MicromarkupTypes { get; set; } = new List<SchemaMarkupValidatorMicromarkupItem>();

        public int ErrorsCount { get; set; }
        public int WarningsCount { get; set; }
    }
}
