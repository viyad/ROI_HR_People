using Android.App;
using Android.Content.PM;
using Android.OS;
using ROI_HR_People.Data;

namespace ROI_HR_People.Droid
{
     [Activity(Label = "ROI_HR_People", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Instance = this;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            App.ManagePerson = new PersonManager(new SoapService());
            LoadApplication(new App());
        }
    }
}