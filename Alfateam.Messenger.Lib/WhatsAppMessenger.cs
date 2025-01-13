using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Lib.Modules.WhatsApp;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.Messengers;
using Alfateam.Messenger.Models.Accounts.SocialNetworks;
using Microsoft.AspNetCore.Routing;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class WhatsAppMessenger : AbsMessenger
    {
        protected AndroidDriver Driver;


        public WhatsAppAccount WhatsAppAccount => Account as WhatsAppAccount;
        public WhatsAppMessenger(WhatsAppAccount account) : base(account)
        {
            Auth = new WhatsAppAuthModule(this);
            Chats = new WhatsAppChatsModule(this);
            Messages = new WhatsAppMessagesModule(this);
            Peers = new WhatsAppPeersModule(this);
            Stickers = new WhatsAppStickersModule(this);

            Init().Wait();
        }


        private async Task Init()
        {
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723/wd/hub");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = "Samsung Galaxy S-XYU",


            };

            driverOptions.AddAdditionalAppiumOption("noReset", true);

            Driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            Driver.ActivateApp("com.viber.voip");
            await Task.Delay(10000);       
        }
    }


}
