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
            await _connection.CreateTableAsync<FavorietLijst>();
            int dogId = currentdog.Id; // turn the currentdog.Id into and integer
            var AddFav = new FavorietLijst { Id = dogId }; // add the currentdog.Id to favoritelist.Id
            await _connection.InsertAsync(AddFav); // insert into the table in the database 


        }
    }
}