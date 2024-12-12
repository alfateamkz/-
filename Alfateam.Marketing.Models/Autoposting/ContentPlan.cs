using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Autoposting
{
    public class ContentPlan : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public bool IsActive { get; set; } = true;



        public List<AutopostingAccount> Accounts { get; set; } = new List<AutopostingAccount>();
        public List<Post> Posts { get; set; } = new List<Post>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
