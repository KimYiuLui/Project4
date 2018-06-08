using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Prototype1.Data;
using System.IO;

namespace Prototype1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Favorieten : ContentPage
	{
        private List<Doggo> _fav;
        private SQLiteAsyncConnection _connection;

        public Favorieten (string dbPath)
		{
            _connection = new SQLiteAsyncConnection(dbPath); // make a sqlite connection with the dbPath which is DogDBThree.db
            InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Doggo>(); // create a table in the databasefile. (if it already exist it won't create it)
            string selectFav = "SELECT * FROM 'FavLijst', 'NewDoggo' WHERE  'FavLijst'.'Id' = 'NewDoggo'.'Id';"; // Query to select the only dog breed that is in Favorite List
            var doggos = await _connection.QueryAsync<Doggo>(selectFav); //apply the query to the Table
            _fav = new List<Doggo>(doggos); // make new Doggo list and put the Query list in the new list 
            if (_fav != null)
            {
                DoggoListView.ItemsSource = _fav;
            }
            _fav.ForEach(Console.WriteLine); // check if it's added to the fav list. 
            base.OnAppearing();
        }

        void DoggoTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        async void DoggoSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var doggo = ((ListView)sender).SelectedItem as Doggo;
            if (doggo != null)
            {
                string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var dbPath = Path.Combine(targetPath, "DogDBFour.db");
                var page = new DoggoDetail(dbPath, doggo); 
                page.BindingContext = doggo;
                await Navigation.PushAsync(page);  // navigate to the "DoggoDetailpage" and give the dbPath and the data of the dog with it
            }
        }
    }
}