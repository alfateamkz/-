using Alfateam.Core;
using Alfateam.Marketing.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Segments
{
    public class Segment : AbsModel
    {
        public string Title { get; set; }
        public CustomersFilter CustomersFilter { get; set; }
        public LeadsFilter LeadsFilter { get; set; }



        public List<MarketingContact> OtherContacts { get; set; } = new List<MarketingContact>();






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
