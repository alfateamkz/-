using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель адреса
    /// </summary>
    public class Address : AbsModel
    {
        public Country Country { get; set; }

        public string State { get; set; }
        public string? District { get; set; }


        public string City { get; set; }

        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set; }
    }
}
