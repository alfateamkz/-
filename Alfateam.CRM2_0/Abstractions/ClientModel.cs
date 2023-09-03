

using Alfateam.CRM2_0.Models.Abstractions;
using System.Collections;

namespace Alfateam.CRM2_0.Abstractions
{
    public abstract class ClientModel
    {
        public int Id { get; set; }


        protected static string GetActualValue(string oldStr, string newStr)
        {
            if (string.IsNullOrEmpty(newStr))
                return oldStr;
            return newStr;
        }
        protected static object GetActualValue(object oldValue, object newValue)
        {
            if (newValue == null)
            {
                return oldValue;
            }
            return newValue;
        }
    }

    public class ClientModel<T> : ClientModel where T : AbsModel
    {

        public ClientModel<T> CreateModel(T item)
        {
            return ClientModel<T>.Create(item);
        }
        public List<ClientModel<T>> CreateModels(IEnumerable<T> items)
        {
            return ClientModel<T>.CreateItems(items);
        }



        public static ClientModel<T> Create(T item)
        {
            var model = new ClientModel<T>();

            var thisProps = model.GetType().GetProperties();
            var props = item.GetType().GetProperties();
            foreach (var prop in props)
            {
                var val = prop.GetValue(item);
                
                var thisProp = thisProps.FirstOrDefault(o => o.Name == prop.Name);  
                if(thisProp != null && thisProp.CanWrite)
                {
                    if(thisProp.PropertyType.GetType() == typeof(ClientModel<AbsModel>))
                    {
                        //TODO: этот кусок кода тщательно протестировать
                        if(val is IEnumerable<AbsModel> enumerable)
                        {
                            val = ClientModel<AbsModel>.CreateItems(enumerable);
                        }
                        else if(val is AbsModel absModel)
                        {
                            val = ClientModel<AbsModel>.Create(absModel);
                        }
                    }

                    thisProp.SetValue(model,val);
                }
            }


            return model;
        }
        public static List<ClientModel<T>> CreateItems(IEnumerable<T> items)
        {
            var models = new List<ClientModel<T>>();
            foreach (var item in items)
            {
                models.Add(Create(item));
            }
            return models;
        }
    }
}
