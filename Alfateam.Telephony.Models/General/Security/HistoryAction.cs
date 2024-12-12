using Alfateam.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.General.Security
{
    public class HistoryAction : AbsModel
    {
        public User CreatedBy { get; set; }
        public int CreatedById { get; set; }



        public string Title { get; set; }
        public string? Description { get; set; }





        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
