using Alfateam.CRM2_0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Staff
{
    /// <summary>
    /// Сущность испытательного срока
    /// </summary>
    public class Probation : AbsModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
