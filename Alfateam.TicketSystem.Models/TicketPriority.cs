using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.TicketSystem.Models
{
    public class TicketPriority : AbsModel
    {
        public TicketPriority()
        {

        }

        public TicketPriority(string title, int priority)
        {
            Title = title;
            Priority = priority;
        }

        public string Title { get; set; }
        public int Priority { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
