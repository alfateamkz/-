using Alfateam.Database.Abstraction;
using Alfateam.Database.Enums.CRM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.CRM {
    public class Resource : BaseModel {

        public string Title { get; set; }
        public string Description { get; set; }

        public ResourceOwnership ResourceOwnership { get; set; } = ResourceOwnership.Alfateam;
        public ResourceStatus Status { get; set; } = ResourceStatus.Available;

        public override string ToString() {
            return Title;
        }
    }
}
