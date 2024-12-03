using Alfateam.Core;
using Alfateam.Marketing.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models
{
    public class BlacklistItem : AbsModel
    {
        public ContactInfo Contact { get; set; }
        public string? Name { get; set; }
        public string? Comment { get; set; }



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
