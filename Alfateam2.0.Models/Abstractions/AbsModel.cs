using Alfateam2._0.Models.ContentItems;
using System;
using System.Collections;
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
            bool isValid = true;

            var props = this.GetType().GetProperties();
            foreach (var prop in props)
            {
                var type = prop.PropertyType;

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
                else if (type == typeof(AbsModel))
                {
                    AbsModel val = (AbsModel)prop.GetValue(this);
                    if(val != null)
                    {
                        isValid &= val.IsValid();
                    }
                }
                else if(type.GetInterfaces().Any(o => o.Name == "IList"))
                {
                    var genericArgument = type.GetGenericArguments().FirstOrDefault();
                    if (genericArgument != null && IsAbsModelType(genericArgument))
                    {
                        var method = type.GetMethod("ToArray");
                        AbsModel[] arr = (AbsModel[])method.Invoke(prop.GetValue(this), null);
                        foreach(var model in arr)
                        {
                            isValid &= model.IsValid();
                        }
                    }
                }
                
            }


            return isValid;
        }

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
