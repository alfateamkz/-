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
    public abstract class AbsModel 
    {
        [Key]
        public int Id { get; set; }



        [JsonIgnore]
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }



        //public DateTime? DeletedAt { get; set; }


        private bool IsAbsModelType(Type type)
        {
            if (type == typeof(AbsModel)) return true;

            var baseModel = type.BaseType;

            if (baseModel == typeof(AbsModel))
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
