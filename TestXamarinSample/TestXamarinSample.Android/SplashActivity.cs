using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TestXamarinSample.Droid {

    [Activity(
        Label                = "TestXamarinSample",
        Icon                 = "@mipmap/icon",
        Theme                = "@style/Theme.Splash",
        MainLauncher         = true,
        NoHistory            = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation    = ScreenOrientation.Portrait,
        LaunchMode           = LaunchMode.SingleTask)]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories     = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme     = "com.ezyhaul.shipper",
        DataHost       = "ezyhaul-dev.auth0.com",
        DataPathPrefix = "/android/com.ezyhaul.shipper/callback")]
    public class SplashActivity : AppCompatActivity
    {
        public static event System.Action<string> Callbacks;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Callbacks?.Invoke(Intent.DataString);
            
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                
                Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            }
            
            InvokeMainActivity();
        }

        private void InvokeMainActivity()
        {
            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivityIntent);
            //            var oidcCallbackActivity = new Intent(this, typeof(OidcCallbackActivity));
            //            StartActivity(oidcCallbackActivity);
        }
    }

}