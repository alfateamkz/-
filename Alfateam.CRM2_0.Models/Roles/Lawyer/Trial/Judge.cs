using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Lawyer.Trial
{
    /// <summary>
    /// Сущность, описывающая судью
    /// </summary>
    public class Judge : AbsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }



        public Country Country { get; set; }
        public string City { get; set; }


        public string Position { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }


    }
}
