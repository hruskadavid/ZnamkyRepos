using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SQLiteExample
{
    public partial class PrehledZnamek : ContentPage
    {
        public PrehledZnamek()
        {
            InitializeComponent();
            fill();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            fill();

        }

        public void zpet(object sender, EventArgs args)
        {

            Navigation.PopModalAsync();
        }

        public void fill()
        {
            var dbConnection = App.Database;
            Database personDatabase = App.Database;
            ListViewFormatted.ItemsSource = App.Database.GetItemsAsync().Result;

        }

        /// <summary>
        /// Možnost smazání položky
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);

            int derp = (int)mi.CommandParameter;
            //vytvoření spojení s db
            var dbConnection = App.Database;
            //db věcí
            Database items = App.Database;
            //přikaz smaž
            App.Database.DeleteItemAsync(App.Database.GetItemAsync(derp).Result);
            //vrat se na domovskou obrazovku
            fill();
            //hlaška
            DisplayAlert("Smazano", "Prvek s ID: " + derp + " byl smazán.", "OK");
        }

    }
}