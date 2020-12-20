using System;
using Xamarin.Forms;
using ROI_HR_People.Models;
using System.Collections.ObjectModel;

namespace ROI_HR_People.Views
{
    public partial class PersonPage : ContentPage
    {
        bool isNewPerson;
		public PersonPage(bool isNew = false)
        {
            InitializeComponent();
            isNewPerson = isNew;
        }

		async void OnSaveActivated(object sender, EventArgs e)
		{
			var person = (Person)BindingContext;
			int result = 0;
			if (person == null ||
					string.IsNullOrWhiteSpace(person.Name) ||
					string.IsNullOrWhiteSpace(person.Phone) ||
					string.IsNullOrWhiteSpace(person.Department) ||
					string.IsNullOrWhiteSpace(person.Street) ||
					string.IsNullOrWhiteSpace(person.City) ||
					string.IsNullOrWhiteSpace(person.State) ||
					string.IsNullOrWhiteSpace(person.Zip) ||
					string.IsNullOrWhiteSpace(person.Country))
			{
				await DisplayAlert("Alert", "All fields are required", "OK");
			}
			else if (!int.TryParse(person.Id, out result))
			{
				await DisplayAlert("Alert", "Id must be a number", "OK");
			}
			else
			{
				await App.ManagePerson.SavePersonAsync(person, isNewPerson);
				if (isNewPerson) await DisplayAlert("Info", "You have successfully added " + person.Name, "OK");
				else await DisplayAlert("Info", "You have successfully updated " + person.Name, "OK");
				await Navigation.PopAsync();
			}
		}

		async void OnDeleteActivated(object sender, EventArgs e)
		{
			var person = (Person)BindingContext;
			await App.ManagePerson.DeletePersonAsync(person);
			await DisplayAlert("Info", "You have successfully deleted " + person.Name, "OK");
			await Navigation.PopAsync();
		}

		async void OnCancelActivated(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}