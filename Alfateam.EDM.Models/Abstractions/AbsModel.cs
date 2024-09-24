using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.EDM.Models.Abstractions
{
    public abstract class AbsModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }




        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt  { get; set; }
    }
}
