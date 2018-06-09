using Prototype1.Data;
using Prototype1.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Prototype1
{
    public partial class MainPage : ContentPage
    {
        private SQLiteAsyncConnection _connection; 
        private List<Doggo> _doggos;
        string overOns =
@"Deze App is gemaakt voor mensen die meer inzicht willen hebben over verschillende honden rassen. Door deze app kan iedereen waar dan ook informatie vinden van verchillende honden rassen.   

Dit project is gemaakt door: 
- Imre Baas
- Ivo Kalverboer
- Kim Yiu Lui
- Hoes Öztürk";


        public MainPage(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath); // make a sqlite connection with the dbPath which is DogDBThree.db
            
            CreateFavoriteDB();
            InitializeComponent();
        }

        async void CreateFavoriteDB()
        {
            await _connection.CreateTableAsync<FavorietLijst>();
        }

        async void ZoekBtnClicked(object sender, System.EventArgs e)
        {
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Path to find a file within the solution
            var dbPath = Path.Combine(targetPath, "DogDBFour.db"); // using the path to look for the DogDBThree.db
            await Navigation.PushAsync(new Zoeken(dbPath)); //navigate to the page "Zoeken" and give the database path with it. 
        }

        async void TestBtnClicked(object sender, System.EventArgs e)
        {
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(targetPath, "DogDBFour.db");
            await Navigation.PushAsync(new QuizPage(dbPath));
        }

        async void RandomBtnClicked(object sender, System.EventArgs e)
        {
            await _connection.CreateTableAsync<Doggo>(); // create a table in the databasefile. (if it already exist it won't create it)
            var doggoss = await _connection.Table<Doggo>().ToListAsync(); //put everything of the database in a list
            _doggos = new List<Doggo>(doggoss); // make a new list of "Doggo" and put the "doggoss" as the values for the new list
            var random = new Random();
            var randomdoggo = random.Next(_doggos.Count); // get a random dog breed 
            if (_doggos[randomdoggo] != null) // check if the random number is not null 
            {
                string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var dbPath = Path.Combine(targetPath, "DogDBFour.db");
                var page = new RandomPage(dbPath, _doggos[randomdoggo]); // navigate to the "DoggoDetailpage" and give the dbPath and the data of the random dog with it
                page.BindingContext = _doggos[randomdoggo]; // set the bindingcontext to the data of the random dog 
                await Navigation.PushAsync(page);
            }
        }

        async void SettingBtnClicked(object sender, System.EventArgs e)
        {
            var instelling =  await DisplayActionSheet("Instellingen", "Annuleren", null, "Aanpassen", "Over ons");
            switch (instelling)
            {
                case "Aanpassen": AanpassenClicked();
                    return;
                case "Over ons": OveronsClicked();
                    return;
            }
        }

        async void OveronsClicked()
        {
           await DisplayAlert("Over ons", overOns, "Terug");
        }

        async void AanpassenClicked()
        {
            var aanpassen = await DisplayActionSheet("Kleuraanpassen", "Annuleren", null, "groen", "wit");
            switch (aanpassen)
            {
                case "groen":
                    App.Current.Resources["backgroundImg"] = "Background.png";
                    return;
                case "wit":
                    App.Current.Resources["backgroundImg"] = "BackgroundOne.png";
                    return;
            }
        }

        async void FavBtnClicked(object sender, System.EventArgs e)
        {
            await _connection.CreateTableAsync<FavorietLijst>();
            string checkquery = "SELECT * FROM 'Favlijst'; ";
            var check = await _connection.QueryAsync<FavorietLijst>(checkquery);
            var checklist = new List<FavorietLijst>(check);
            if (checklist.Count() != 0)
            {
                try
                {
                    string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    var dbPath = Path.Combine(targetPath, "DogDBFour.db");
                    await Navigation.PushAsync(new Favorieten(dbPath)); // navigate to the "Favorieten" list }
                }
                catch
                {
                    await DisplayAlert("Notificatie", "U heeft nog geen hond toegevoegd aan de favorietenlijst", "Oké");
                }
            }
            else
                await DisplayAlert("Notificatie", "U heeft nog geen hond toegevoegd aan de favorietenlijst", "Oké");
        }
    }
}
