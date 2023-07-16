using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Orders {
    public class BudgetItem : BaseModel {

        public string Title { get; set; }
        public string? Description { get; set; } = "";

        public double Sum { get; set; }
    }
}
