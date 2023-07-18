using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Сущность стоимости
    /// </summary>
    public class Cost : AbsModel
    {
        public Currency Currency { get; set; }
        public double Price { get; set; }
    }
}
