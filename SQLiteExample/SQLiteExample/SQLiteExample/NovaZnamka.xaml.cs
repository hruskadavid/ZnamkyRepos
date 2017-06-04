using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SQLiteExample
{
    public partial class NovaZnamka : ContentPage
    {


        ObservableCollection<ZnamkaCislo> Znamky = new ObservableCollection<ZnamkaCislo>();
        private string VybranaZnamka;
        public void zpet(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }
        public NovaZnamka()
        {

            InitializeComponent();
            Znamky.Add(new ZnamkaCislo { CoZnamka = "1" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "2" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "3" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "4" });
            Znamky.Add(new ZnamkaCislo { CoZnamka = "5" });
            ZnamkyView.ItemsSource = Znamky;
        }
        void SelectedItemMethod(object sender, SelectedItemChangedEventArgs e)
        {
            //Vybírání známek z listview
            VybranaZnamka = e.SelectedItem.ToString();
        }
        public void ulozit(object sender, EventArgs args)
        {
            //vytvoření spojení s db
            var dbConnection = App.Database;
            //db uživatelu
            Database userDatabase = App.Database;

            //list pro dočasne uložení
            if (VybranaZnamka != null && predmet.Text != null && vaha.Text != null)
            {
                Znamka item = new Znamka();
                item.Hodnoceni = Convert.ToInt16(VybranaZnamka);
                item.Predmet = predmet.Text;
                item.Vaha = Convert.ToInt16(vaha.Text);


                //zapis dat do db
                App.Database.SaveItemAsync(item);
                //vrat se na domovskou obrazovku
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Upozornění", " Vyplňte všechny  hodnoty", "OK");
            }
        }
    }
}
