using Prototype1.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Prototype1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Zoeken : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private List<Doggo> _doggos;
        public Doggo doggo;

        public Zoeken(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath); // make a sqlite connection with the dbPath which is DogDBThree.db
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Doggo>(); // create a table in the databasefile. (if it already exist it won't create it)
            var doggos = await _connection.QueryAsync<Doggo>("SELECT * FROM NewDoggo ORDER BY Name ASC"); //put everything of the database in a list
            doggos.ToList();
            _doggos = new List<Doggo>(doggos); // make a new list of "Doggo" and put the "doggoss" as the values for the new list
            DoggoListView.ItemsSource = _doggos; // set the bindingcontext to the data of the dog 
            base.OnAppearing();
        }

        void DoggoTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        async void DoggoSelected(object sender, SelectedItemChangedEventArgs e)
        {

            this.doggo = ((ListView)sender).SelectedItem as Doggo;
            if (this.doggo != null)
            {
                string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var dbPath = Path.Combine(targetPath, "DogDBFour.db");
                var page = new DoggoDetail(dbPath, doggo); 
                page.BindingContext = this.doggo; // set the binding context for the "DoggoDetail" page
                await Navigation.PushAsync(page); //navigate to "DoggoDetail" and add the dbPath and the selected doggo
            }
        }

        //search bar that looks for a dog that contains the text the user has inserted
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            DoggoListView.BeginRefresh();

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                DoggoListView.ItemsSource = _doggos;
            else
                DoggoListView.ItemsSource = _doggos.Where(i => i.Name.ToLower().Contains(e.NewTextValue));

            DoggoListView.EndRefresh();
        }
    }
}