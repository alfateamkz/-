using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Alfateam.EDSSigningApp
{
    [IntentFilter(actions: new string[] {"android.intent.action.VIEW" },DataScheme ="alfakey")]
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
