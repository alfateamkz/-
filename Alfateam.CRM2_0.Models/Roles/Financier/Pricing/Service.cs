using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Financier.Pricing
{
    /// <summary>
    /// Модель услуги, которую оказывает компания
    /// </summary>
    public class Service : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
