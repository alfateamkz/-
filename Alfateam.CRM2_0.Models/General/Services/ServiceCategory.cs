using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General.Services
{
    /// <summary>
    /// Сущность категории услуг, которые предоставляет компания
    /// </summary>
    public class ServiceCategory : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public List<ServiceCategory> Subcategories { get; set; } = new List<ServiceCategory>();
    }
}
