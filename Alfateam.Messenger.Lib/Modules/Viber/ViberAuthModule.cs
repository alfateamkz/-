using Alfateam.Core.Helpers;
using Alfateam.Messenger.Lib.Abstractions.Modules;
using Alfateam.Messenger.Lib.Enums;
using Alfateam.Messenger.Lib.Extensions;
using Alfateam.Messenger.Lib.Models;
using Alfateam.Messenger.Lib.Models.Images;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Android.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Messenger.Lib.Modules.Viber
{
    public class ViberAuthModule : AuthModule
    {
        //com.android.permissioncontroller.permission.ui.GrantPermissionsActivity

        private ViberMessenger Messenger;
        public ViberAuthModule(ViberMessenger messenger)
        {
            Messenger = messenger;
        }


        public override async Task<AuthResult> Auth()
        {
            if(Messenger.Driver.CurrentActivity == ".splash.SplashActivity")
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text='Start now']")).Click();
                await Task.Delay(5000);
            }

            if (Messenger.Driver.CurrentActivity == ".registration.RegistrationActivity")
            {
                var code = PhoneNumberHelper.GetPhoneCode(Messenger.ViberAccount.Login);
                var phoneWithoutCountryCode = PhoneNumberHelper.GetPhoneWithoutCountryCode(Messenger.ViberAccount.Login);

                var countryCodeInput = Messenger.Driver.FindElement(By.XPath("//*[@text='1']"));
                countryCodeInput.Clear();
                countryCodeInput.SendKeys(code.Pfx);
                Messenger.Driver.FindElement(By.XPath("//*[@text='Phone number']")).SendKeys(phoneWithoutCountryCode);

                Messenger.Driver.TryFindElement(By.XPath("//*[@text='Continue']")).Click();
                await Task.Delay(2000);
                Messenger.Driver.TryFindElement(By.XPath("//*[@text='Continue']"))?.Click();
                await Task.Delay(5000);
            }

            await HandleAndroidPermissions();

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"You'll receive a free call\"]")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text='Next']")).Click();
                await Task.Delay(2000);

                Messenger.Driver.TryFindElement(By.XPath("//*[@text='Call me']"))?.Click();

                return AuthResult.Create(AuthResultType.TwoFARequired, "Введите последние 4 цифры номера телефона, который сейчас позвонит Вам");
            }

            return AuthResult.Create(AuthResultType.TwoFARequired, "Введите код из SMS");
        }
        public override async Task<AuthResult> ConfirmAuth(string code)
        {
            var inputs = Messenger.Driver.FindElements(By.XPath("//*")).Where(o => o.IsInput()).ToList();
            for (int i = 0; i < inputs.Count; i++)
            {
                inputs[i].Clear();
            }

            for (int i = 0; i < inputs.Count; i++)
            {
                inputs[i].SendKeys(code[i].ToString());
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Incorrect code']")) != null)
            {
                return AuthResult.Create(AuthResultType.Invalid2FACode);
            }

            return AuthResult.Create(AuthResultType.Authorized);
        }
        public override Task<Request2FACodeResult> Request2FACode()
        {
            var callMeAgainBtn = Messenger.Driver.TryFindElement(By.XPath("//*[@text='Call me again']"));
            if (callMeAgainBtn != null)
            {
                callMeAgainBtn.Click();
            }


            throw new NotImplementedException();
        }



        public override async Task<string> GetOurUserId()
        {
            Messenger.Driver.StartActivity(ViberMessenger.APP_BUNDLE_ID, ".WelcomeActivity");
            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Chats\"]")) != null) //Проверяем, есть ли кнопка чатов. Если да, то авторизованы
            {
                return Messenger.ViberAccount.Login;
            }
            return null;
        }
        public override async Task<UserInfo> GetOurUserInfo()
        {
            Messenger.Driver.StartActivity(ViberMessenger.APP_BUNDLE_ID, ".WelcomeActivity");
            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Chats\"]")) == null) //Проверяем, есть ли кнопка чатов. Если да, то авторизованы 
            {
                return null;
            }

            Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"More\"]")).Click();
            await Task.Delay(7000);


            var elems = Messenger.Driver.FindElements(By.XPath("//*")).ToList();
            
            var iii2 = elems.Select(o => o.GetResourceId()).ToList();

            var phoneTextViewIndex = elems.IndexOf(elems.FirstOrDefault(o => o.Text == $"+{Messenger.Account.Login}")); //номер телефона
            var userTitle = elems[phoneTextViewIndex - 1].Text; //чуть выше имя и фамилия
            var imageScreenshot = elems.FirstOrDefault(o => o.GetResourceId() == "com.viber.voip:id/photo").GetScreenshot(); //аватар

            return new UserInfo
            {
                Avatar = new Base64ImageFile(imageScreenshot.AsBase64EncodedString),
                Name = userTitle,
                Id = Messenger.ViberAccount.Login,
            };
        }




        #region Private methods

        private async Task HandleAndroidPermissions()
        {
            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to access your contacts?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Don’t allow\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to access your phone call logs?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Don’t allow\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to make and manage phone calls?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Don’t allow\"]")).Click();
                await Task.Delay(2000);
            }
        }
        private async Task HandleAuthorizedAndroidPermissions()
        {
            //TODO: not tested
            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to take pictures and record video?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"While using the app\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to access this device's location?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Don’t allow\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to record audio?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"While using the app\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to access your contacts?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Don’t allow\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to make and manage phone calls?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Don’t allow\"]")).Click();
                await Task.Delay(2000);
            }

            if (Messenger.Driver.TryFindElement(By.XPath("//*[@text='Allow Viber to access photos and media on your device?']")) != null)
            {
                Messenger.Driver.TryFindElement(By.XPath("//*[@text=\"Allow\"]")).Click();
                await Task.Delay(2000);
            }
        }

   
        #endregion
    }
}
