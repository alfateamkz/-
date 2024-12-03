using Alfateam.Core;
using Alfateam.Marketing.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.Templates
{
    public class Template : AbsModel
    {
        public string Title { get; set; }
        public ContactType Type { get; set; }
        public string TemplateContent { get; set; }






        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
