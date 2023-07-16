using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель сведений о компании 
    /// </summary>
    public class Company : AbsModel
    {
        public Country Country { get; set; }
        public LegalForm Form { get; set; }


        public string LegalName { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }
    }
}
