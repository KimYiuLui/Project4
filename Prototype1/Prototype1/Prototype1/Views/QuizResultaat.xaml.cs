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
    public partial class QuizResultaat : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private List<Doggo> _doggos;

        // do something whenever the "Hi" message is sent
        // using the 'arg' parameter which is a string

            public QuizResultaat(string dbPath)
        {
            Console.WriteLine(QuizPage.GlobalVariables.QueryQuiz);
            _connection = new SQLiteAsyncConnection(dbPath);
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Doggo>();
            var doggos = await _connection.Table<Doggo>().ToListAsync();
            _doggos = new List<Doggo>(doggos);
            QuizListView.ItemsSource = _doggos;
            base.OnAppearing();
        }

        void QuizTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        async void QuizSelected(object sender, SelectedItemChangedEventArgs e)
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