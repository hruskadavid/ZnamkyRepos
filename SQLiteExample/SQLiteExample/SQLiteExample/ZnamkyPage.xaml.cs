using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SQLiteExample
{
    public partial class ZnamkyPage : ContentPage
    {
        public ZnamkyPage()
        {
            InitializeComponent();
            fill();
        }

        /// <summary>
        /// Provede se při navratu sem
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            fill();

        }
        /// <summary>
        /// Naplní ListView
        /// </summary>
        public void fill()
        {
            var dbConnection = App.Database;
            Database personDatabase = App.Database;
            double cprumer = 0;
            int cvaha = 0;
            int cabsence = 0;

            List<string> Predmety = new List<string>();
            List<Znamka> Znamky = App.Database.GetItemsAsync().Result;
            List<CPredmet> Vys = new List<CPredmet>();
            foreach (var item in Znamky)
            {
                if (!Predmety.Contains(item.Predmet))
                {
                    Predmety.Add(item.Predmet);
                }
                cprumer = cprumer + item.PravaZnamka();
                if (item.Hodnoceni == 0) { cabsence++; }
                cvaha = cvaha + item.Vaha;
            }

            foreach (string item in Predmety)
            {
                CPredmet cpredmet = new CPredmet();
                List<Znamka> prumer = Znamky.FindAll(s => s.Predmet == item && s.Hodnoceni != 0);
                cpredmet.Znamek = prumer.Count();
                cpredmet.Prumer = Math.Round(prumer.Average(x => x.PravaZnamka()), 2) / 10;
                System.Diagnostics.Debug.WriteLine(Math.Round(prumer.Average(x => x.PravaZnamka()), 2) / 10);
                System.Diagnostics.Debug.WriteLine("derp" + cpredmet.Prumer + "derp");
                cpredmet.Predmet = item;
                cpredmet.Absence = Znamky.Count(s => s.Hodnoceni == 0);
                Vys.Add(cpredmet);

            }

            ListViewFormatted.ItemsSource = Vys;

        }

        /// <summary>
        /// Funkce pro rychlé zadaní známek a zobrazení pruměru
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void rychloPocet(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new rychloPocet());
        }

        public async void SelectedItemMethod(object sender, ItemTappedEventArgs e)
        {
            //otevře novou stranku
            await Navigation.PushModalAsync(new PrehledZnamek());
        }

        /// <summary>
        /// Stranka přidání znamky
        /// </summary>
        /// <returns>The pridat.</returns>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        public void pridat(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new NovaZnamka());
        }

    }
}
