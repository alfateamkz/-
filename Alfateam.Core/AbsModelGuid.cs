using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core
{
    public class AbsModelGuid : AbsModelBase
    {
        [Key]
        [SwaggerIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

    }
}
