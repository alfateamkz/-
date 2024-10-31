using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.General
{
    public class TimezoneLocalization : LocalizableModel
    {
        public string Title { get; set; }


        public int TimeZoneId { get; set; }
    }
}
