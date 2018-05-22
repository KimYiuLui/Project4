using Prototype1.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype1
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string dbPath)
        {
            InitializeComponent();
        }

        async void ZoekBtnClicked(object sender, System.EventArgs e)
        {
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(targetPath, "NewDoggoDB.db");
            await Navigation.PushAsync(new Zoeken(dbPath));
        }
        void TestBtnClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("NOTE", "Currently under construction no action avialable yet.", "OK");
        }

        void RandomBtnClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("NOTE", "Currently under construction no action avialable yet.", "OK");
        }

        void SettingBtnClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("NOTE", "Currently under construction no action avialable yet.", "OK");
        }
    }
}
