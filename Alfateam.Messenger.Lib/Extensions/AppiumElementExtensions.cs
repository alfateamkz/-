using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Extensions
{
    public static class AppiumElementExtensions
    {
        public static string GetElementType(this AppiumElement element)
        {
            return element.GetAttribute("class");
        }

        public static string GetResourceId(this AppiumElement element)
        {
            return element.GetAttribute("resourceId");
        }

        public static string GetName(this AppiumElement element)
        {
            return element.GetAttribute("name");
        }

        public static string GetContentDescription(this AppiumElement element)
        {
            return element.GetAttribute("contentDescription");
        }

        public static string GetPackage(this AppiumElement element)
        {
            return element.GetAttribute("package");
        }













        public static bool IsInput(this AppiumElement element)
        {
            return element.GetAttribute("class") == "android.widget.EditText";
        }

        public static bool IsImage(this AppiumElement element)
        {
            return element.GetAttribute("class") == "android.widget.ImageView";
        }

    }
}
