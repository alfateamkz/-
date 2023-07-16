using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.General
{
    /// <summary>
    /// Модель судебной структуры
    /// </summary>
    public class CourtStructure : AbsModel
    {
        public Country Country { get; set; } 

        public string Title { get; set; }


        //TODO : доделать систему судов и исков
    }
}
