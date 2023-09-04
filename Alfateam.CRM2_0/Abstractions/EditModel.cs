using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;

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
                else if (Nullable.GetUnderlyingType(typeof(int)) == typeof(int))
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
                    itemSameProp.SetValue(item, prop.GetValue(this));
                }
            }
        }

        public T Create()
        {
            var newItem = new T();
            this.Fill(newItem);
            newItem.Id = 0;

            return newItem;
        }
    }
}
