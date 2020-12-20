using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ROI_HR_People.Data;
using ROI_HR_People.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ROI_HR_People
{
    public class App : Application
	{
		public static PersonManager ManagePerson { get; set; }

		public App()
		{
			MainPage = new NavigationPage(new PeoplePage());
			((NavigationPage)MainPage).BarBackgroundColor = Color.FromHex("#941a1d");
			((NavigationPage)MainPage).BarTextColor = Color.FromHex("#ffffff");
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
