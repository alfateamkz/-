using Alfateam.Core.Attributes.DTO;
using Alfateam.Core.Enums;
using Alfateam.Website.API.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Core.Helpers
{
    public static class DTOJsonSerialization
    {
        public static string SerializeSampleModel(Type dtoModelType, DTOJsonSerializationType type)
        {
            List<Type> describedTypes = new List<Type>();

            var model = Activator.CreateInstance(dtoModelType);
            SetSampleModelValues(model, type);

            return Serialize(model, type);
        }

        private static void SetSampleModelValues(object model, DTOJsonSerializationType type)
        {
            SetSampleModelValuesRecursively(model, type, new List<Type>());
        }
        private static void SetSampleModelValuesRecursively(object model, DTOJsonSerializationType type, List<Type> describedTypes)
        {
            if(model == null || describedTypes.Any(o => o == model.GetType()))
            {
                return;
            }


            foreach (var prop in model.GetType().GetProperties().Where(o => o.CanWrite))
            {
                if(describedTypes.Any(o => o == prop.PropertyType))
                {
                    continue;
                }

                if (DTOModelAbs.IsModelTypeOf(prop.PropertyType, typeof(DTOModelAbs)))
                {
                    describedTypes.Add(prop.PropertyType);
                }

                prop.SetValue(model, MakeSampleValueIfNull(prop.PropertyType, prop.GetValue(model)));

              
            }

            foreach (var prop in model.GetType().GetProperties().Where(o => o.CanWrite))
            {
                if (DTOModelAbs.IsModelTypeOf(prop.PropertyType, typeof(DTOModelAbs)))
                {
                    SetSampleModelValuesRecursively(prop.GetValue(model), type, describedTypes);
                }
                else if (prop.PropertyType.GetInterfaces().Any(o => o == typeof(IEnumerable)) && prop.PropertyType != typeof(string))
                {
                    var arrayItemType = prop.PropertyType.GetGenericArguments()[0];
                    if (DTOModelAbs.IsModelTypeOf(arrayItemType, typeof(DTOModelAbs)))
                    {
                        describedTypes.Add(arrayItemType);

                        var list = (prop.GetValue(model) as IEnumerable).Cast<DTOModelAbs>().ToList();
                        foreach (var item in list)
                        {
                            SetSampleModelValuesRecursively(item, type, describedTypes);
                        }

                      
                    }

                    

                }
            }
        }




        public static string Serialize(object item, DTOJsonSerializationType type)
        {
            var jsonObj = new ExpandoObject();

            SetJsonFieldsRecursively(jsonObj, item, type);
            return JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        }
        private static void SetJsonFieldsRecursively(ExpandoObject jsonObj, object item, DTOJsonSerializationType type)
        {
            foreach (var prop in GetProperties(item, type))
            {
                var propVal = prop.GetValue(item);

                if (DTOModelAbs.IsModelTypeOf(prop.PropertyType, typeof(DTOModelAbs)))
                {
                    var subExpandoObject = new ExpandoObject();
                    jsonObj.TryAdd(prop.Name, subExpandoObject);
                    SetJsonFieldsRecursively(subExpandoObject, propVal as DTOModelAbs, type);
                }
                else if (prop.PropertyType.GetInterfaces().Any(o => o == typeof(IEnumerable)) && prop.PropertyType != typeof(string))
                {
                    var arrayItemType = prop.PropertyType.GetGenericArguments()[0];
                    if(DTOModelAbs.IsModelTypeOf(arrayItemType, typeof(DTOModelAbs)))
                    {

                        var jsonArray = new List<ExpandoObject>();

                        List<object> list = (propVal as IEnumerable).Cast<object>().ToList();
                        foreach (var arrayItem in list)
                        {
                            var jsonArrayItem = new ExpandoObject();
                            SetJsonFieldsRecursively(jsonArrayItem, arrayItem as DTOModelAbs, type);
                            jsonArray.Add(jsonArrayItem);
                        }

                        jsonObj.TryAdd(prop.Name, jsonArray);
                    }
                    else
                    {
                        jsonObj.TryAdd(prop.Name, propVal);
                    }
                }
                else
                {
                    jsonObj.TryAdd(prop.Name, propVal);
                }
            }
        }


        private static IEnumerable<PropertyInfo> GetProperties(object item, DTOJsonSerializationType type)
        {
            var neededProps = new List<PropertyInfo>();

            if(item is null)
            {
                return neededProps;
            }

            foreach(var prop in item.GetType().GetProperties())
            {

                if(type == DTOJsonSerializationType.GET 
                    && !prop.GetCustomAttributes().Any(o => o is HiddenFromClient || o is DTOHiddenField))
                {
                    neededProps.Add(prop);
                }
                else if (type != DTOJsonSerializationType.GET && !prop.GetCustomAttributes().Any(o => o is ForClientOnly || o is DTOHiddenField))
                {
                    var fieldForAttr = prop.GetCustomAttributes().FirstOrDefault(o => o is DTOFieldFor) as DTOFieldFor;
                    if (fieldForAttr != null)
                    {
                        if (fieldForAttr.For == DTOFieldForType.CreationOnly && type == DTOJsonSerializationType.POST)
                        {
                            neededProps.Add(prop);
                        }
                        else if (fieldForAttr.For == DTOFieldForType.UpdateOnly && type == DTOJsonSerializationType.PUT)
                        {
                            neededProps.Add(prop);
                        }
                    }
                    else
                    {
                        neededProps.Add(prop);
                    }
                }
            }


            return neededProps;
        }


        private static object MakeSampleValueIfNull(Type propType, object val)
        {
            if(val == null)
            {
                if(propType == typeof(string))
                {
                    return "строка";
                }
                return Activator.CreateInstance(propType);
            }
            else
            {
                if (propType.GetInterfaces().Any(o => o == typeof(IEnumerable)) && propType != typeof(string))
                {
                    List<object> list = (val as IEnumerable).Cast<object>().ToList();
                    if(list.Count == 0)
                    {
                        var arrayItemType = propType.GetGenericArguments()[0];
                        val.GetType().GetMethods().FirstOrDefault(o => o.Name == "Add").Invoke(val, new object[] { Activator.CreateInstance(arrayItemType) });
                    }
                }


                return val;
            }
        }
    }
}
