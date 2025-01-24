using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models
{
    public class TicketCategory : AbsModel
    {
        public TicketCategory()
        {

        }

        public TicketCategory(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public List<TicketCategory> Subcategories { get; set; } = new List<TicketCategory>();

        
        /// <summary>
        /// ID родителя
        /// </summary>
        public int? TicketCategoryId { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
