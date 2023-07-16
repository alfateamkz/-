using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models
{
    public class CallRequest : BaseModel {

        public string Name { get; set; }
        public string Phone { get; set; }
        public bool WasCall { get; set; }
    }
}
