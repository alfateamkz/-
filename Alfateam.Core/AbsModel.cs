using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam.Core
{
    /// <summary>
    /// Базовая модель
    /// </summary>
    public abstract class AbsModel : AbsModelBase
    {
        [Key]
        [SwaggerIgnore]
        public int Id { get; set; }
    }
}
