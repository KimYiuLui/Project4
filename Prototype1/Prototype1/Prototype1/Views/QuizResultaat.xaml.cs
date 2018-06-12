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
    public partial class QuizResultaat : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private List<Doggo> _doggos;
        public string _query;
        public Doggo doggo;


        // do something whenever the "Hi" message is sent
        // using the 'arg' parameter which is a string

        public QuizResultaat(string dbPath, string quizlist)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            this._query = quizlist;
            Console.WriteLine(_query);
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Doggo>();
            var selectfilter = await _connection.QueryAsync<Doggo>(_query);
            _doggos = new List<Doggo>(selectfilter);
            DoggoListView.ItemsSource = _doggos;
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
                page.BindingContext = doggo;

                //page.BindingContext = this.doggo; // set the binding context for the "DoggoDetail" page
                await Navigation.PushAsync(page); //navigate to "DoggoDetail" and add the dbPath and the selected doggo
            }
        }
    }
}