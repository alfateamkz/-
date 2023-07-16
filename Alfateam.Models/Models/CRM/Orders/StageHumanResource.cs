using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Orders {
    public class StageHumanResource : BaseModel {

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }


        public string Description { get; set; }
    }
}
