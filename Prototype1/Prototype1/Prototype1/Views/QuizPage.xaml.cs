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
    public partial class QuizPage : ContentPage
    {
        //Database stuff
        private SQLiteAsyncConnection _connection;
        // Text boven aan het scherm
        private Label Vraag1;
        private Label Vraag2;
        private Label Vraag3;
        private Label Vraag4;
        private Label Vraag5;
        //private Label Vraag6;
        //private Label Vraag7;
        //private Label Vraag8;
        //private Label Vraag9;
        //private Label Vraag10;
        public static class GlobalVariables
        {
            public static string QueryQuiz = "SELECT Name FROM NewDoggo WHERE ";
        }
        //Plaatjes
        
        private Image Image1;
        private Image Image2;
        private Image Image3;
        private Image Image4;
        private Image Image5;
        //Vraag 1 
        private Button Antwoord1A;
        private Button Antwoord1B;
        private Button Antwoord1C;
        //Vraag 1 
        private Button Antwoord2A;
        private Button Antwoord2B;
        private Button Antwoord2C;
        //Vraag 1 
        private Button Antwoord3A;
        private Button Antwoord3B;
        private Button Antwoord3C;
        //Vraag 1 
        private Button Antwoord4A;
        private Button Antwoord4B;
        private Button Antwoord4C;
        //Vraag 1 
        private Button Antwoord5A;
        private Button Antwoord5B;
        private Button Antwoord5C;
        //Vraag 1 
        //private Button Antwoord6A;
        //private Button Antwoord6B;
        //private Button Antwoord6C;
        ////Vraag 1 
        //private Button Antwoord7A;
        //private Button Antwoord7B;
        //private Button Antwoord7C;
        ////Vraag 1 
        //private Button Antwoord8A;
        //private Button Antwoord8B;
        //private Button Antwoord8C;
        ////Vraag 1 
        //private Button Antwoord9A;
        //private Button Antwoord9B;
        //private Button Antwoord9C;
        ////Vraag 1 
        //private Button Antwoord10A;
        //private Button Antwoord10B;
        //private Button Antwoord10C;

        public QuizPage(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            InitializeComponent();
            //Text Descriptie
            Image1 = this.FindByName<Image>("Image_Xaml1");
            Image2 = this.FindByName<Image>("Image_Xaml2");
            Image3 = this.FindByName<Image>("Image_Xaml3");
            Image4 = this.FindByName<Image>("Image_Xaml4");
            Image5 = this.FindByName<Image>("Image_Xaml5");

            Vraag1 = this.FindByName<Label>("VraagNummer_Xaml1");
            Vraag2 = this.FindByName<Label>("VraagNummer_Xaml2");
            Vraag3 = this.FindByName<Label>("VraagNummer_Xaml3");
            Vraag4 = this.FindByName<Label>("VraagNummer_Xaml4");
            Vraag5 = this.FindByName<Label>("VraagNummer_Xaml5");
            //Vraag6 = this.FindByName<Label>("VraagNummer_Xaml6");
            //Vraag7 = this.FindByName<Label>("VraagNummer_Xaml7");
            //Vraag8 = this.FindByName<Label>("VraagNummer_Xaml8");
            //Vraag9 = this.FindByName<Label>("VraagNummer_Xaml9");
            //Vraag10 = this.FindByName<Label>("VraagNummer_Xaml10");
            //Vraag 1
            Antwoord1A = this.FindByName<Button>("Antwoord1A_Xaml");
            Antwoord1B = this.FindByName<Button>("Antwoord1B_Xaml");
            Antwoord1C = this.FindByName<Button>("Antwoord1C_Xaml");
            //Vraag 2
            Antwoord2A = this.FindByName<Button>("Antwoord2A_Xaml");
            Antwoord2B = this.FindByName<Button>("Antwoord2B_Xaml");
            Antwoord2C = this.FindByName<Button>("Antwoord2C_Xaml");
            //Vraag 3
            Antwoord3A = this.FindByName<Button>("Antwoord3A_Xaml");
            Antwoord3B = this.FindByName<Button>("Antwoord3B_Xaml");
            Antwoord3C = this.FindByName<Button>("Antwoord3C_Xaml");
            //Vraag 4
            Antwoord4A = this.FindByName<Button>("Antwoord4A_Xaml");
            Antwoord4B = this.FindByName<Button>("Antwoord4B_Xaml");
            Antwoord4C = this.FindByName<Button>("Antwoord4C_Xaml");
            //Vraag 5
            Antwoord5A = this.FindByName<Button>("Antwoord5A_Xaml");
            Antwoord5B = this.FindByName<Button>("Antwoord5B_Xaml");
            Antwoord5C = this.FindByName<Button>("Antwoord5C_Xaml");
            ////Vraag 6
            //Antwoord6A = this.FindByName<Button>("Antwoord6A_Xaml");
            //Antwoord6B = this.FindByName<Button>("Antwoord6B_Xaml");
            //Antwoord6C = this.FindByName<Button>("Antwoord6C_Xaml");
            ////Vraag 7
            //Antwoord7A = this.FindByName<Button>("Antwoord7A_Xaml");
            //Antwoord7B = this.FindByName<Button>("Antwoord7B_Xaml");
            //Antwoord7C = this.FindByName<Button>("Antwoord7C_Xaml");
            ////Vraag 8
            //Antwoord8A = this.FindByName<Button>("Antwoord8A_Xaml");
            //Antwoord8B = this.FindByName<Button>("Antwoord8B_Xaml");
            //Antwoord8C = this.FindByName<Button>("Antwoord8C_Xaml");
            ////Vraag 9
            //Antwoord9A = this.FindByName<Button>("Antwoord9A_Xaml");
            //Antwoord9B = this.FindByName<Button>("Antwoord9B_Xaml");
            //Antwoord9C = this.FindByName<Button>("Antwoord9C_Xaml");
            ////Vraag 10
            //Antwoord10A = this.FindByName<Button>("Antwoord10A_Xaml");
            //Antwoord10B = this.FindByName<Button>("Antwoord10B_Xaml");
            //Antwoord10C = this.FindByName<Button>("Antwoord10C_Xaml");
        }
        //Vraag 1 
        void Answer1A(object sender, System.EventArgs e)
        {
            // AntwoordA.Visibility = ViewStates.Gone;
            Antwoord1A.IsVisible = false;
            Antwoord1B.IsVisible = false;
            Antwoord1C.IsVisible = false;
            Antwoord2A.IsVisible = true;
            Antwoord2B.IsVisible = true;
            Antwoord2C.IsVisible = true;
            Vraag1.IsVisible = false;
            Vraag2.IsVisible = true;
            Image1.IsVisible = false;
            Image2.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "Care = 'weinig' ";

        }

        void Answer1B(object sender, System.EventArgs e)
        {
            Antwoord1A.IsVisible = false;
            Antwoord1B.IsVisible = false;
            Antwoord1C.IsVisible = false;
            Antwoord2A.IsVisible = true;
            Antwoord2B.IsVisible = true;
            Antwoord2C.IsVisible = true;
            Vraag1.IsVisible = false;
            Vraag2.IsVisible = true;
            Image1.IsVisible = false;
            Image2.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "Care = 'gemiddeld' ";
        }

        void Answer1C(object sender, System.EventArgs e)
        {
            Antwoord1A.IsVisible = false;
            Antwoord1B.IsVisible = false;
            Antwoord1C.IsVisible = false;
            Antwoord2A.IsVisible = true;
            Antwoord2B.IsVisible = true;
            Antwoord2C.IsVisible = true;
            Vraag1.IsVisible = false;
            Vraag2.IsVisible = true;
            Image1.IsVisible = false;
            Image2.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "Care = 'veel' ";
        }
        //Vraag 2
        void Answer2A(object sender, System.EventArgs e)
        {
            Antwoord2A.IsVisible = false;
            Antwoord2B.IsVisible = false;
            Antwoord2C.IsVisible = false;
            Antwoord3A.IsVisible = true;
            Antwoord3B.IsVisible = true;
            Vraag2.IsVisible = false;
            Vraag3.IsVisible = true;
            Image2.IsVisible = false;
            Image3.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND (TypeOne = 'gezeldschap' OR TypeTwo = 'gezelschap') ";
        }

        void Answer2B(object sender, System.EventArgs e)
        {
            Antwoord2A.IsVisible = false;
            Antwoord2B.IsVisible = false;
            Antwoord2C.IsVisible = false;
            Antwoord3A.IsVisible = true;
            Antwoord3B.IsVisible = true;
            Image2.IsVisible = false;
            Image3.IsVisible = true;
            Vraag2.IsVisible = false;
            Vraag3.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND (TypeOne = 'werk' OR TypeTwo = 'werk') ";
        }

        void Answer2C(object sender, System.EventArgs e)
        {
            Antwoord2A.IsVisible = false;
            Antwoord2B.IsVisible = false;
            Antwoord2C.IsVisible = false;
            Antwoord3A.IsVisible = true;
            Antwoord3B.IsVisible = true;
            Image2.IsVisible = false;
            Image3.IsVisible = true;
            Vraag2.IsVisible = false;
            Vraag3.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND (TypeOne = 'jacht' OR TypeTwo = 'jacht') ";

        }

        //Vraag 3
        void Answer3A(object sender, System.EventArgs e)
        {
            Antwoord3A.IsVisible = false;
            Antwoord3B.IsVisible = false;
            Antwoord4A.IsVisible = true;
            Antwoord4B.IsVisible = true;
            Antwoord4C.IsVisible = true;
            Vraag3.IsVisible = false;
            Vraag4.IsVisible = true;
            Image3.IsVisible = false;
            Image4.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Childfriendly = 'Kindvriendelijk' ";
        }

        void Answer3B(object sender, System.EventArgs e)
        {
            Antwoord3A.IsVisible = false;
            Antwoord3B.IsVisible = false;
            Antwoord4A.IsVisible = true;
            Antwoord4B.IsVisible = true;
            Antwoord4C.IsVisible = true;
            Vraag3.IsVisible = false;
            Vraag4.IsVisible = true;
            Image3.IsVisible = false;
            Image4.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Childfriendly = 'Niet kindvriendelijk' ";

        }

        //void Answer3C(object sender, System.EventArgs e)
        //{
        //    Antwoord3A.IsVisible = false;
        //    Antwoord3B.IsVisible = false;
        //    Antwoord3C.IsVisible = false;
        //    Antwoord4A.IsVisible = true;
        //    Antwoord4B.IsVisible = true;
        //    Antwoord4C.IsVisible = true;
        //    Vraag3.IsVisible = false;
        //    Vraag4.IsVisible = true;
        //    Image3.IsVisible = false;
        //    Image4.IsVisible = true;
        //}

        //Vraag 4
        void Answer4A(object sender, System.EventArgs e)
        {
            Antwoord4A.IsVisible = false;
            Antwoord4B.IsVisible = false;
            Antwoord4C.IsVisible = false;
            Antwoord5A.IsVisible = true;
            Antwoord5B.IsVisible = true;
            Antwoord5C.IsVisible = true;
            Vraag4.IsVisible = false;
            Vraag5.IsVisible = true;
            Image4.IsVisible = false;
            Image5.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Exercise = 'laag' ";


        }

        void Answer4B(object sender, System.EventArgs e)
        {
            Antwoord4A.IsVisible = false;
            Antwoord4B.IsVisible = false;
            Antwoord4C.IsVisible = false;
            Antwoord5A.IsVisible = true;
            Antwoord5B.IsVisible = true;
            Antwoord5C.IsVisible = true;
            Vraag4.IsVisible = false;
            Vraag5.IsVisible = true;
            Image4.IsVisible = false;
            Image5.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Exercise = 'gemiddeld' ";
        }

        void Answer4C(object sender, System.EventArgs e)
        {
            Antwoord4A.IsVisible = false;
            Antwoord4B.IsVisible = false;
            Antwoord4C.IsVisible = false;
            Antwoord5A.IsVisible = true;
            Antwoord5B.IsVisible = true;
            Antwoord5C.IsVisible = true;
            Vraag4.IsVisible = false;
            Vraag5.IsVisible = true;
            Image4.IsVisible = false;
            Image5.IsVisible = true;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Exercise = 'veel' ";
        }

        //Vraag 5
        async void Answer5A(object sender, System.EventArgs e)
        {
            Antwoord5A.IsVisible = false;
            Antwoord5B.IsVisible = false;
            Antwoord5C.IsVisible = false;
            Image5.IsVisible = false;
            Vraag5.IsVisible = false;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Fur = 'kort' ";
            Console.WriteLine(GlobalVariables.QueryQuiz);
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(targetPath, "DogDBOne.db");
            await Navigation.PushAsync(new QuizResultaat(dbPath));
        }

        async void Answer5B(object sender, System.EventArgs e)
        {
            Antwoord5A.IsVisible = false;
            Antwoord5B.IsVisible = false;
            Antwoord5C.IsVisible = false;
            Image5.IsVisible = false;
            Vraag5.IsVisible = false;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Fur = 'gemiddeld' ";
            Console.WriteLine(GlobalVariables.QueryQuiz);
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(targetPath, "DogDBOne.db");
            await Navigation.PushAsync(new QuizResultaat(dbPath));
        }

        async void Answer5C(object sender, System.EventArgs e)
        {
            Antwoord5A.IsVisible = false;
            Antwoord5B.IsVisible = false;
            Antwoord5C.IsVisible = false;
            Image5.IsVisible = false;
            Vraag5.IsVisible = false;
            GlobalVariables.QueryQuiz = GlobalVariables.QueryQuiz + "AND Fur = 'lang'";
            string targetPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbPath = Path.Combine(targetPath, "DogDBOne.db");
            await Navigation.PushAsync(new QuizResultaat(dbPath));
        }

        //Vraag 6
        //void Answer6A(object sender, System.EventArgs e)
        //{
        //    Antwoord6A.IsVisible = false;
        //    Antwoord6B.IsVisible = false;
        //    Antwoord6C.IsVisible = false;
        //    Antwoord7A.IsVisible = true;
        //    Antwoord7B.IsVisible = true;
        //    Antwoord7C.IsVisible = true;
        //    Vraag6.IsVisible = false;
        //    Vraag7.IsVisible = true;
        //}

        //void Answer6B(object sender, System.EventArgs e)
        //{
        //    Antwoord6A.IsVisible = false;
        //    Antwoord6B.IsVisible = false;
        //    Antwoord6C.IsVisible = false;
        //    Antwoord7A.IsVisible = true;
        //    Antwoord7B.IsVisible = true;
        //    Antwoord7C.IsVisible = true;
        //    Vraag6.IsVisible = false;
        //    Vraag7.IsVisible = true;
        //}

        //void Answer6C(object sender, System.EventArgs e)
        //{
        //    Antwoord6A.IsVisible = false;
        //    Antwoord6B.IsVisible = false;
        //    Antwoord6C.IsVisible = false;
        //    Antwoord7A.IsVisible = true;
        //    Antwoord7B.IsVisible = true;
        //    Antwoord7C.IsVisible = true;
        //    Vraag6.IsVisible = false;
        //    Vraag7.IsVisible = true;
        //}

        ////Vraag 7
        //void Answer7A(object sender, System.EventArgs e)
        //{
        //    Antwoord7A.IsVisible = false;
        //    Antwoord7B.IsVisible = false;
        //    Antwoord7C.IsVisible = false;
        //    Antwoord8A.IsVisible = true;
        //    Antwoord8B.IsVisible = true;
        //    Antwoord8C.IsVisible = true;
        //    Vraag7.IsVisible = false;
        //    Vraag8.IsVisible = true;
        //}

        //void Answer7B(object sender, System.EventArgs e)
        //{
        //    Antwoord7A.IsVisible = false;
        //    Antwoord7B.IsVisible = false;
        //    Antwoord7C.IsVisible = false;
        //    Antwoord8A.IsVisible = true;
        //    Antwoord8B.IsVisible = true;
        //    Antwoord8C.IsVisible = true;
        //    Vraag7.IsVisible = false;
        //    Vraag8.IsVisible = true;
        //}

        //void Answer7C(object sender, System.EventArgs e)
        //{
        //    Antwoord7A.IsVisible = false;
        //    Antwoord7B.IsVisible = false;
        //    Antwoord7C.IsVisible = false;
        //    Antwoord8A.IsVisible = true;
        //    Antwoord8B.IsVisible = true;
        //    Antwoord8C.IsVisible = true;
        //    Vraag7.IsVisible = false;
        //    Vraag8.IsVisible = true;
        //}

        ////Vraag 8
        //void Answer8A(object sender, System.EventArgs e)
        //{
        //    Antwoord8A.IsVisible = false;
        //    Antwoord8B.IsVisible = false;
        //    Antwoord8C.IsVisible = false;
        //    Antwoord9A.IsVisible = true;
        //    Antwoord9B.IsVisible = true;
        //    Antwoord9C.IsVisible = true;
        //    Vraag8.IsVisible = false;
        //    Vraag9.IsVisible = true;
        //}

        //void Answer8B(object sender, System.EventArgs e)
        //{
        //    Antwoord8A.IsVisible = false;
        //    Antwoord8B.IsVisible = false;
        //    Antwoord8C.IsVisible = false;
        //    Antwoord9A.IsVisible = true;
        //    Antwoord9B.IsVisible = true;
        //    Antwoord9C.IsVisible = true;
        //    Vraag8.IsVisible = false;
        //    Vraag9.IsVisible = true;
        //}

        //void Answer8C(object sender, System.EventArgs e)
        //{
        //    Antwoord8A.IsVisible = false;
        //    Antwoord8B.IsVisible = false;
        //    Antwoord8C.IsVisible = false;
        //    Antwoord9A.IsVisible = true;
        //    Antwoord9B.IsVisible = true;
        //    Antwoord9C.IsVisible = true;
        //    Vraag8.IsVisible = false;
        //    Vraag9.IsVisible = true;
        //}

        ////Vraag 9
        //void Answer9A(object sender, System.EventArgs e)
        //{
        //    Antwoord9A.IsVisible = false;
        //    Antwoord9B.IsVisible = false;
        //    Antwoord9C.IsVisible = false;
        //    Antwoord10A.IsVisible = true;
        //    Antwoord10B.IsVisible = true;
        //    Antwoord10C.IsVisible = true;
        //    Vraag9.IsVisible = false;
        //    Vraag10.IsVisible = true;
        //}

        //void Answer9B(object sender, System.EventArgs e)
        //{
        //    Antwoord9A.IsVisible = false;
        //    Antwoord9B.IsVisible = false;
        //    Antwoord9C.IsVisible = false;
        //    Antwoord10A.IsVisible = true;
        //    Antwoord10B.IsVisible = true;
        //    Antwoord10C.IsVisible = true;
        //    Vraag9.IsVisible = false;
        //    Vraag10.IsVisible = true;
        //}

        //void Answer9C(object sender, System.EventArgs e)
        //{
        //    Antwoord9A.IsVisible = false;
        //    Antwoord9B.IsVisible = false;
        //    Antwoord9C.IsVisible = false;
        //    Antwoord10A.IsVisible = true;
        //    Antwoord10B.IsVisible = true;
        //    Antwoord10C.IsVisible = true;
        //    Vraag9.IsVisible = false;
        //    Vraag10.IsVisible = true;
        //}

        ////Vraag 10
        //void Answer10A(object sender, System.EventArgs e)
        //{
        //    Antwoord10A.IsVisible = false;
        //    Antwoord10B.IsVisible = false;
        //    Antwoord10C.IsVisible = false;
        //    DisplayAlert("NOTE", "That's all folks.", "OK");

        //}

        //void Answer10B(object sender, System.EventArgs e)
        //{
        //    Antwoord10A.IsVisible = false;
        //    Antwoord10B.IsVisible = false;
        //    Antwoord10C.IsVisible = false;
        //    DisplayAlert("NOTE", "That's all folks.", "OK");
        //}

        //void Answer10C(object sender, System.EventArgs e)
        //{
        //    Antwoord10A.IsVisible = false;
        //    Antwoord10B.IsVisible = false;
        //    Antwoord10C.IsVisible = false;
        //    DisplayAlert("NOTE", "That's all folks.", "OK");
        //}



    }
}