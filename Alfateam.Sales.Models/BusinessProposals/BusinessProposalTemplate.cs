using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.BusinessProposals
{
    public class BusinessProposalTemplate : AbsModel
    {
        public string Title { get; set; }
        public string HTMLContent { get; set; }
        public List<BPTemplatePlaceholder> Placeholders { get; set; } = new List<BPTemplatePlaceholder>();





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
