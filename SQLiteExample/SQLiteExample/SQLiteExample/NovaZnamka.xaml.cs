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
        public class ZnamkaCislo
        {
            public string CoZnamka { get; set; }
            public override string ToString()
            {
                return CoZnamka;
            }
        }
        
        ObservableCollection<ZnamkaCislo> Znamky = new ObservableCollection<ZnamkaCislo>();
        private string lel;

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
            
             lel = e.SelectedItem.ToString();
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
        public void ulozit(object sender, EventArgs args)
        {
            //vytvoření spojení s db
            var dbConnection = App.Database;
            //db uživatelu
            Database userDatabase = App.Database;

            //list pro dočasne uložení
            
            Znamka item = new Znamka();
            item.Hodnoceni = Convert.ToInt16(lel);
            item.Predmet = predmet.Text;
            item.Vaha = Convert.ToInt16(vaha.Text);

            //zapis dat do db
            App.Database.SaveItemAsync(item);
            //vrat se na domovskou obrazovku
            Navigation.PopModalAsync();
        }
    }
}
