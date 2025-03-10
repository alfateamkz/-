﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using System.Collections;

namespace Alfateam.CRM2_0.Abstractions
{
    public abstract class EditModel
    {
        public int Id { get; set; }

        public virtual bool IsValid()
        {
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
                else if (Nullable.GetUnderlyingType(typeof(int)) == typeof(int) && prop.Name.Contains("Id"))
                {
                    int? val = (int)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        isValid &= val.Value > 0;
                    }
                }

            }


            return isValid;
        }
    

    }

    public abstract class EditModel<T> : EditModel where T: AbsModel, new()
    {
        public virtual void Fill(T item)
        {
            var props = this.GetType().GetProperties();
            var itemProps = item.GetType().GetProperties();

            foreach (var prop in props)
            {
                if (prop.Name == "Id")
                {
                    continue;
                }

                var itemSameProp = itemProps.FirstOrDefault(o => o.Name == prop.Name);
                if (itemSameProp != null && itemSameProp.CanWrite)
                {
                    ////TODO: ТЩАТЕЛЬНО ПРОВЕРИТЬ ЭТОТ КУСОК КОДА
                    //if(prop.PropertyType == typeof(EditModel<>))
                    //{
                    //    var propValue = prop.GetValue(this);
                    //    var createMethod = propValue.GetType().GetMethod("Create");
                    //    itemSameProp.SetValue(item, createMethod.Invoke(propValue, new object[] {}));
                    //}
                    //else if(prop.PropertyType == typeof(IEnumerable) 
                    //    && prop.PropertyType.GenericTypeArguments.Any(o => o == typeof(EditModel)))
                    //{
                    //    var propValueArray = prop.GetValue(this) as IEnumerable<EditModel<>>;
                        
                    //}
                    //else
                    //{
                    //    itemSameProp.SetValue(item, prop.GetValue(this));
                    //}

                    itemSameProp.SetValue(item, prop.GetValue(this));
                }
            }
        }

       
    }
}
