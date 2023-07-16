using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM.Orders {
    public class StageMaterialResource : BaseModel {


        public Resource? Resource { get; set; }
        public int? ResourceId { get; set; }


        public string Description { get; set; }
    }
}
