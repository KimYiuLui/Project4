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



        public DoggoDetail (string dbPath, Doggo dog)
		{
            _connection = new SQLiteAsyncConnection(dbPath); 
            this.currentdog = dog; // add the binding data to the variable currentdog
            BindingContext = this.currentdog;
			InitializeComponent ();
		}

        async void Button_Clicked(object sender, EventArgs e)
        {
            int dogId = currentdog.Id; // turn the currentdog.Id into and integer
            await _connection.CreateTableAsync<FavorietLijst>();
            try
            {
                var AddFav = new FavorietLijst { Id = dogId }; // add the currentdog.Id to favoritelist.Id
                await _connection.InsertAsync(AddFav); // insert into the table in the database 
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
                var DelFav = new FavorietLijst { Id = dogId }; // add the currentdog.Id to favoritelist.Id
                await _connection.DeleteAsync(DelFav); // insert into the table in the database 
            }
            catch
            {
                await DisplayAlert("Notificatie", "Deze hond staat niet in uw favorietenlijst. Je kan deze hond niet uit je favorietenlijst verweideren", "Oké");// if currentId is in dogId => displayalert 
            }

        }
        
    }
}