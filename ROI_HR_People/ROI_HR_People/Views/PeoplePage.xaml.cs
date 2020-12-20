using System;
using Xamarin.Forms;
using ROI_HR_People.Models;

namespace ROI_HR_People.Views
{
    public partial class PeoplePage : ContentPage
    {
        public PeoplePage()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
            
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            string imageLocation = GetImageimageLocation();
            imgLogo.Source = ImageSource.FromFile(imageLocation);
        }

        private string GetImageimageLocation()
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            bool style1 = (navigationPage.BarBackgroundColor == Color.FromHex("#941a1d"));
            string imageLocation = "";
            if (style1)
                imageLocation = (Height > Width ? "ROILogo_small_r.png" : "ROILogo_r.png");
            else
                imageLocation = "ROILogo_b.png"; 

            return imageLocation;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ManagePerson.GetPeopleAsync();
        }

        async void OnAddPersonClicked(object sender, EventArgs e)
        {
            var person = new Person();
            var personPage = new PersonPage(true);
            personPage.BindingContext = person;
            await Navigation.PushAsync(personPage);
        }

        async void OnPersonSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var person = e.SelectedItem as Person;
            var personPage = new PersonPage();
            personPage.BindingContext = person;
            await Navigation.PushAsync(personPage);
        }

        async void OnItem_Clicked(object sender, EventArgs e)
        {
            ToolbarItem toolbarItem = (ToolbarItem)sender;
            var navigationPage = Application.Current.MainPage as NavigationPage;
            string imageLocation = "";
            var page = new Page();

            switch (toolbarItem.Text.ToLower())
            {
                case "theme 1":
                    navigationPage.BarBackgroundColor = Color.FromHex("#941a1d");
                    imageLocation = GetImageimageLocation();
                    imgLogo.Source = ImageSource.FromFile(imageLocation);
                    this.BackgroundColor = Color.FromHex("#fff");
                    Resources["DynamicTitleStyle"] = Resources["TitleStyle1"];
                    Resources["DynamicSettingsLabelStyle"] = Resources["listviewLabelStyle1"];
                    break;
                case "theme 2":
                    navigationPage.BarBackgroundColor = Color.FromHex("#595959");
                    imageLocation = GetImageimageLocation();
                    imgLogo.Source = ImageSource.FromFile(imageLocation);
                    this.BackgroundColor = Color.FromHex("#000");
                    Resources["DynamicTitleStyle"] = Resources["TitleStyle2"];
                    Resources["DynamicSettingsLabelStyle"] = Resources["listviewLabelStyle2"];
                    break;
                case "help":
                    page = new ManualPage();
                    await Navigation.PushAsync(page);
                    break;
                case "faq":
                    page = new FAQ();
                    await Navigation.PushAsync(page);
                    break;
                default:
                    break;
            }
        }
    }
}
