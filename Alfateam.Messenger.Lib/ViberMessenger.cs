using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Lib.Exceptions;
using Alfateam.Messenger.Lib.Modules.Telegram;
using Alfateam.Messenger.Lib.Modules.Viber;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.Accounts.Messengers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib
{
    public class ViberMessenger : AbsMessenger
    {
        internal AndroidDriver Driver;
        internal const string APP_BUNDLE_ID = "com.viber.voip";


        public ViberAccount ViberAccount => Account as ViberAccount;
        public ViberMessenger(ViberAccount account) : base(account)
        {
            Auth = new ViberAuthModule(this);
            Chats = new ViberChatsModule(this);
            Messages = new ViberMessagesModule(this);
            Peers = new ViberPeersModule(this);
            Stickers = new ViberStickersModule(this);

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
                EnableDownloads = true,
                AcceptInsecureCertificates = true,
            };
            driverOptions.AddAdditionalAppiumOption("noReset", true);

            


            Driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Driver.ActivateApp(ViberMessenger.APP_BUNDLE_ID);
            await Task.Delay(10000);

            var act = Driver.CurrentActivity;
            var act2 = Driver.CurrentPackage;


            var user = await Chats.GetChat("79043260186");

           // await Auth.Request2FACode();

           // await Auth.ConfirmAuth("2407");
        }


        internal async Task ThrowIfNotAuthorized()
        {
            var userId = await Auth.GetOurUserId();
            if (string.IsNullOrEmpty(userId))
            {
                throw new AlfateamMessengerUnauthorizedException();
            }
        }
    }
}
