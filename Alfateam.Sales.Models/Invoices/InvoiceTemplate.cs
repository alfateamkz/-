using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.Invoices
{
    public class InvoiceTemplate : AbsModel
    {
        public string Title { get; set; }
        public string HTMLContent { get; set; }




        public List<InvoiceTemplatePlaceholder> Placeholders { get; set; } = new List<InvoiceTemplatePlaceholder>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
