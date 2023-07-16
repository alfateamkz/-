using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Abstractions
{
    public class PostItem : BaseModel {

        public int Order { get; set; }

        [NotMapped]
        public virtual string Type { get;}    
    }
}
