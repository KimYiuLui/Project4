using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prototype1.Data;
using Prototype1.Views;
using System.IO;
using SQLite;
using Xamarin.Forms.Internals;

namespace Prototype1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoggoDetail : ContentPage
	{
        public Doggo currentdog;
        public List<Doggo> calledList = new List<Doggo>();
        private SQLiteAsyncConnection _connection;
        private List<Doggo> _doggos;
        private int dogId;

        public DoggoDetail (string dbPath, Doggo dog)
		{
            _connection = new SQLiteAsyncConnection(dbPath);
            this.currentdog = dog; // add the binding data to the variable currentdog
            this.dogId = currentdog.Id;
            BindingContext = this.currentdog;

            InitializeComponent();

            FavCheck(dogId);
        }

        async void FavCheck(int dogID)
        {
            await _connection.CreateTableAsync<FavorietLijst>();
            string checkquery = "SELECT * FROM 'Favlijst' WHERE 'FavLijst'.'Id' = " + dogId + "; ";
            var check = await _connection.QueryAsync<FavorietLijst>(checkquery);
            var checklist = new List<FavorietLijst>(check);
            if (checklist.Count() <= 0)
            {
                FavXAML.Icon = "fav.png";
                FavXAML.Clicked -= RemoveButton_Clicked;
                FavXAML.Clicked += Button_Clicked;
            }
            else
            {
                FavXAML.Icon = "unfav.png";
                FavXAML.Clicked -= Button_Clicked;
                FavXAML.Clicked += RemoveButton_Clicked;
            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await _connection.CreateTableAsync<FavorietLijst>();
            try
            {
                var AddFav = new FavorietLijst { Id = dogId }; // add the currentdog.Id to favoritelist.Id
                await _connection.InsertAsync(AddFav); // insert into the table in the database 
                FavCheck(dogId);
            }
            catch
            {
                await DisplayAlert("Notificatie", "Deze hond staat al in uw favorietenlijst", "Oké");// if currentId is in dogId => displayalert 
            }

        }
        async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            int dogId = currentdog.Id; // turn the currentdog.Id into and integer
            await _connection.CreateTableAsync<FavorietLijst>();
            try
            {
                var DelFav = new FavorietLijst { Id = dogId }; // select the current dog from favorite list 
                await _connection.DeleteAsync(DelFav); // delete the current dog from favorite list
                FavCheck(dogId);
            }
            catch
            {
                await DisplayAlert("Notificatie", "Deze hond staat niet in uw favorietenlijst. Je kan deze hond niet uit je favorietenlijst verweideren", "Oké");// if currentId is in dogId => displayalert 
            }

        }

        async void Homeclicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

    }
}