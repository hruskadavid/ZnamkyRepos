using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace SQLiteExample
{
    public partial class rychloPocet : ContentPage
    {
        ObservableCollection<ZnamkaCislo> Znamky = new ObservableCollection<ZnamkaCislo>();
        private string lel;
        List<Znamka> znamka = new List<Znamka>();
        public rychloPocet()
        {
            InitializeComponent();
            Znamky.Add(new ZnamkaCislo { CoZnamka = "1" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "2" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "3" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "4" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "5" });
            ZnamkyView.ItemsSource = Znamky;
        }

        public void zpet(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
        void SelectedItemMethod(object sender, SelectedItemChangedEventArgs e)
        {
            //Vybírání známek z listview
            lel = e.SelectedItem.ToString();
        }
        public void pridat(object sender, EventArgs args)
        {
            //Přidání známek do listu, 100% funkčnost na telefonu
            znamka.Add(new Znamka() { Hodnoceni = Convert.ToInt16(lel), Vaha = Convert.ToInt16(vaha.Text) });

            double y = znamka.Average(x => x.PravaZnamka());

            prumer.Text = Convert.ToString(Math.Round(y, 2));
            //ListViewFormatted.ItemsSource = " "; //odkomentovat pouze na telefonu
            ListViewFormatted.ItemsSource = znamka;

        }
    }
}