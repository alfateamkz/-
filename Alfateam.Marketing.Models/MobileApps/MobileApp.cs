using Alfateam.Core;
using Alfateam.Marketing.Models.Abstractions.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.Models.MobileApps
{
    public class MobileApp : AbsModel
    {
        public string Title { get; set; }


        public MobileAppGroup Group { get; set; }
        public int GroupId { get; set; }



        public List<MobileAppIntegration> Integrations { get; set; } = new List<MobileAppIntegration>();



        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
