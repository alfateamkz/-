using Alfateam.Database.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triggero.Models.Attributes;
using Triggero.Models.Enums;

namespace Alfateam.Database.Models.Abstractions
{
    public class LocalizationModel : BaseModel {

        public Language Language { get; set; }
        [GeneratorField("", GeneratorControlType.Hidden)]
        public int LanguageId { get; set; }
    }
}
