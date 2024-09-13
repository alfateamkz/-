using Microsoft.AspNetCore.Mvc;

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

        public AdminLocalizationPageStructureItem(string title, string commonMethodName)
        {
            Title = title;
            SetMethodNames(commonMethodName);
        }



        public string Title { get; set; }

        public string CrtUpdController => "AdminCrtUpdInterfaceTexts/";
        public string GetController => "AdminAllInterfaceTexts/";
        

        public string GetMethod { get; set; }
        public string CrtUpdMethod { get; set; }


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
    }
}
