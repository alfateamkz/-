using Alfateam.EDSSigningApp.Models;
using Alfateam.EDSSigningApp.Popups;
using Alfateam.EDSSigningApp.Views;
using Newtonsoft.Json;
using RGPopup.Maui.Extensions;

namespace Alfateam.EDSSigningApp
{
    public partial class App : Application
    {
        public const string Version = "0.0.1";
        public static string EDSDirectory => System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "EDS");
        public static string SettingsFilePath => System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "settings.json");
        public static AppSettings Settings { get; set; }
        public App()
        {
            InitializeComponent();
            LoadSettings();

            MainPage = new Alfateam.EDSSigningApp.Pages.SelectCert();  
        }


        public static Alfateam.EDSSigningApp.Pages.MainPage NavigatedMainPage => Current.MainPage as Alfateam.EDSSigningApp.Pages.MainPage;


        public static void LoadSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                Settings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(SettingsFilePath));
            }
        }

        public static void SaveSettings()
        {
            File.WriteAllText(SettingsFilePath, JsonConvert.SerializeObject(Settings));
        }





        protected override async void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            //alfakey://test?a=b
            // Show an alert to test the app link worked

            await this.Dispatcher.DispatchAsync(() =>
            {
                this.Windows[0].Page!.DisplayAlert(
                    "App Link Opened",
                    uri.ToString(),
                    "OK");
            });

            Console.WriteLine("APP LINK: " + uri.ToString());
        }


        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);
            window.Activated += Window_Activated;
            return window;
        }
        private async void Window_Activated(object sender, EventArgs e)
        {
            if (DeviceInfo.Platform == DevicePlatform.WinUI
                || DeviceInfo.Platform == DevicePlatform.macOS)
            {
                var window = sender as Window;
                window.MaximumWidth = 814;
                window.MaximumHeight = 695;
                window.Width = 814;
                window.Height = 695;
              

                // give it some time to complete window resizing task.
                await window.Dispatcher.DispatchAsync(() => { });

                var disp = DeviceDisplay.Current.MainDisplayInfo;

                // move to screen center
                window.X = (disp.Width / disp.Density - window.Width) / 2;
                window.Y = (disp.Height / disp.Density - window.Height) / 2;
            }
          



        }
    }
}
