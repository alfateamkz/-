using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель объекта недвижимого имущества
    /// </summary>
    public class RealEstate : AbsModel
    {
        public Address Address { get; set; }


        public RealEstateType Type { get; set; } = RealEstateType.Office;
        public double Square { get; set; }
        public int Floors { get; set; }
        public bool HasBasement { get; set; }




    }
}
