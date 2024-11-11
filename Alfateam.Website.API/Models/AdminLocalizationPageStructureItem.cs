using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Alfateam.Website.API.Models
{
    public class AdminLocalizationPageStructureItem
    {
        public AdminLocalizationPageStructureItem()
        {

        }
        public AdminLocalizationPageStructureItem(string title)
        {
            Title = title;
        }


        public AdminLocalizationPageStructureItem(string title, string commonMethodName, Type typeOfObject)
        {
            Title = title;

            SetMethodNames(commonMethodName);
            SetObjectStructureFields(typeOfObject);
        }


        public AdminLocalizationPageStructureItem(string title, string commonMethodName)
        {
            Title = title;

            SetMethodNames(commonMethodName);
        }
        public AdminLocalizationPageStructureItem(string title, Type typeOfObject)
        {
            Title = title;

            SetObjectStructureFields(typeOfObject);
        }


        public string Title { get; set; }

        public string CrtUpdController => "AdminCrtUpdInterfaceTexts/";
        public string GetController => "AdminAllInterfaceTexts/";
        

        public string GetMethod { get; set; }
        public string CrtUpdMethod { get; set; }

        public List<AdminLocalizationPageField> ObjectStructure { get; set; } = new List<AdminLocalizationPageField>();



        public string CommonMethodName 
        { 
            init
            {
                SetMethodNames(value);
            }
        }

        public bool IsExpander => string.IsNullOrEmpty(GetMethod) && string.IsNullOrEmpty(CrtUpdMethod);

        public List<AdminLocalizationPageStructureItem> SubPages { get; set; } = new List<AdminLocalizationPageStructureItem>();



        private void SetMethodNames(string commonMethodName)
        {
            GetMethod = $"Get{commonMethodName}";
            CrtUpdMethod = $"CrtUpd{commonMethodName}";
        }
        private void SetObjectStructureFields(Type typeOfObject)
        {
            var props = typeOfObject.GetProperties().Where(o => o.CanWrite);
            foreach (var prop in props)
            {
                string clientFieldName = prop.Name;

                var descriptionAttr = prop.GetCustomAttributes(true).FirstOrDefault(o => o is DescriptionAttribute) as DescriptionAttribute;
                if(descriptionAttr != null)
                {
                    clientFieldName = descriptionAttr.Description;
                }

                ObjectStructure.Add(new AdminLocalizationPageField()
                {
                    ClientFieldName = clientFieldName,
                    JSONName = prop.Name,
                    Type = prop.PropertyType.Name,
                });
            }
        }
    }
}
