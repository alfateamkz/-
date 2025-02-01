using Microsoft.Extensions.Logging;
using RGPopup.Maui.Extensions;
using UraniumUI;
using Xe.AcrylicView;

namespace Alfateam.EDSSigningApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUIBlurs()
                .UseUraniumUI()
                .UseAcrylicView()
                 .UseMauiRGPopup(config =>
                 {
                     config.BackPressHandler = null;
                     config.FixKeyboardOverlap = true;
                 })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Gilroy-Bold.tff", "GilroyBold");
                    fonts.AddFont("Gilroy-Regular.tff", "GilroyRegular");
                    fonts.AddFont("Gilroy-RegularItalic.tff", "GilroyRegularItalic");
                    fonts.AddFont("Gilroy-SemiBold.tff", "GilroySemiBold");

                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


    }
}
