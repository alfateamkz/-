using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Texts.Common
{
    /// <summary>
    /// Сущность текстов футера
    /// </summary>
    public class FooterTexts : AbsModel
    {
        public string AllRightReserved { get; set; }



        public string Team { get; set; }
        public string Partners { get; set; }
        public string News { get; set; }
        public string Contacts { get; set; }


        public string LeaveRequest { get; set; }
        public string OurWorks { get; set; }
        public string ServicesCost { get; set; }
        public string AboutUs { get; set; }
    }
}
