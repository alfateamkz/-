using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Extensions
{
    public static class AndroidDriverExtensions
    {
        public static AppiumElement TryFindElement(this AndroidDriver driver, By by)
        {
            return driver.FindElements(by).FirstOrDefault();
        }

        public static void Deeplink(this AndroidDriver driver, string url, string bundleId)
        {
            driver.ExecuteScript("mobile: deepLink", new Dictionary<string, object>() {
                {"url", url},
                {"package", bundleId }
            });
        }
    }
}
