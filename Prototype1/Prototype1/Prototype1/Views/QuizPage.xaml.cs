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
    public partial class QuizPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;

        public QuizPage(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            InitializeComponent();
        }

        void Answer1A(object sender, System.EventArgs e)
        {
            DisplayAlert("NOTE", "Antwoord A", "OK");
           // AntwoordA.Visibility = ViewStates.Gone;

        }

        void Answer1B(object sender, System.EventArgs e)
        {
            DisplayAlert("NOTE", "Antwoord B", "OK");
        }

        void Answer1C(object sender, System.EventArgs e)
        {
            DisplayAlert("NOTE", "Antwoord C", "OK");
        }

    }
}