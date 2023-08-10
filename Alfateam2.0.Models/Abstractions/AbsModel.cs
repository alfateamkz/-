using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
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
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }



        public virtual bool IsValid()
        {
            //TODO: может быть большая проблема, на автоайдишниках не нужно чекать, если создание сущности
            //TODO: нужно проходиться так же по AbsModel и List<AbsModel>, чтобы корректно работало

            bool isValid = true;

            var props = this.GetType().GetProperties();
            foreach (var prop in props)
            {
                var type = prop.GetType();

                if (type == typeof(string))
                {
                    isValid &= string.IsNullOrEmpty(prop.GetValue(this) as string);
                }
                else if (type == typeof(int) && prop.Name.Contains("Id"))
                {
                    int val = (int)prop.GetValue(this);
                    isValid &= val > 0;
                }
                else if (Nullable.GetUnderlyingType(typeof(int)) == typeof(int) && prop.Name.EndsWith("Id"))
                {
                    int? val = (int)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        isValid &= val.Value > 0;
                    }
                }
                else if (type == typeof(Content))
                {
                    Content val = (Content)prop.GetValue(this);
                    isValid &= val.IsValid();
                }

            }


            return isValid;
        }
    }
}
