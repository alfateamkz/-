using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.ServicePages
{
    public class ServicePageServiceRibbonItem : AbsModel
    {
        public string Title { get; set; }


        public int? ServicePageId { get; set; }
        public int? ServicePageLocalizationId { get; set; }
    }
}
