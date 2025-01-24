using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core
{
    public abstract class AbsModelBase
    {

        [JsonIgnore]
        [SwaggerIgnore]
        public bool IsDeleted { get; set; }

        [SwaggerIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        [SwaggerIgnore]
        public DateTime? UpdatedAt { get; set; }

        //public DateTime? DeletedAt { get; set; }


        private bool IsAbsModelType(Type type)
        {
            if (type == typeof(AbsModelBase)) return true;

            var baseModel = type.BaseType;

            if (baseModel == typeof(AbsModelBase))
            {
                return true;
            }
            else if (baseModel != typeof(Object))
            {
                return IsAbsModelType(baseModel);
            }
            return false;
        }
    }
}
