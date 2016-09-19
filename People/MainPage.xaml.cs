using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using People.Models;
using Xamarin.Forms;

namespace People
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public async void OnNewButtonClicked(object sender, EventArgs e)
		{
			statusMessage.Text = "";
			await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
			statusMessage.Text = App.PersonRepo.StatusMessage;
		}

		public async void OnGetButtonClicked(object sender, EventArgs e)
		{
			statusMessage.Text = "";
			ObservableCollection<Person> people = new ObservableCollection<Person>(await App.PersonRepo.GetAllPeopleAsync());
			peopleList.ItemsSource = people;
		}
	}
}
