using Alfateam.Core;
using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Outstaff
{
    /// <summary>
    /// Сетка аутстафф услуг
    /// </summary>
    public class OutstaffMatrix : AbsModel
    {
        public List<OutstaffColumn> Columns { get; set; } = new List<OutstaffColumn>();
        public List<OutstaffItem> Items { get; set; } = new List<OutstaffItem>();
    }
}
