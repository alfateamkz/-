using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Services
{
    /// <summary>
    /// Сущность, которая описывает услугу, которуб предоставляет компания
    /// </summary>
    public class Service : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }

        public ServicePriceType PriceType { get; set; } = ServicePriceType.MinimumPrice;
        public ServiceCategory Category { get; set; }
    }
}
