using Prototype1.Data;
using SQLite;
using System;
using System.Collections.Generic;
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

        public Zoeken(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Doggo>();
            var doggos = await _connection.Table<Doggo>().ToListAsync();
            _doggos = new List<Doggo>(doggos);
            DoggoListView.ItemsSource = _doggos;
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
                var page = new DoggoDetail();
                page.BindingContext = doggo;
                await Navigation.PushAsync(page);


            }
        }

    }
}