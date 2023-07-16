using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;
using Triggero.Models.Enums;

namespace Alfateam.Database.Abstraction {
    public class BaseModel {

        [Key]
        [GeneratorField("", GeneratorControlType.Hidden)]
        public int Id { get; set; }

        [GeneratorField("", GeneratorControlType.Hidden)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [GeneratorField("", GeneratorControlType.Hidden)]
        public bool IsDeleted { get; set; }
        [GeneratorField("", GeneratorControlType.Hidden)]
        public DateTime? DeletedAt { get; set; }
    }
}
