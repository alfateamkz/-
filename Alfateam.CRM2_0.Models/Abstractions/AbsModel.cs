using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions
{
    public abstract class AbsModel : IEqualityComparer<AbsModel>
    {
        [Key]
        public int Id { get; set; }



        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }



        public bool Equals(AbsModel? x, AbsModel? y)
        {
            return x != null && y != null & x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] AbsModel obj)
        {
            return obj.Id.GetHashCode() ^ obj.CreatedAt.GetHashCode();
        }

        public virtual bool IsValidToUpdate()
        {
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
                else if (type == typeof(AbsModel))
                {
                    AbsModel val = (AbsModel)prop.GetValue(this);
                    if (val != null)
                    {
                        isValid &= val.IsValidToUpdate();
                    }
                }
                else if (type.GetInterfaces().Any(o => o.Name == "IList"))
                {
                    var genericArgument = type.GetGenericArguments().FirstOrDefault();
                    if (genericArgument != null && IsAbsModelType(genericArgument))
                    {
                        var method = type.GetMethod("ToArray");
                        AbsModel[] arr = (AbsModel[])method.Invoke(prop.GetValue(this), null);
                        foreach (var model in arr)
                        {
                            isValid &= model.IsValidToUpdate();
                        }
                    }
                }

            }


            return isValid;
        }

        public virtual bool IsValidToCreate()
        {
            //TODO: IsValidToUpdate, на автоайдишниках не нужно чекать, если создание сущности

            return IsValidToUpdate();
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
