using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQLiteExample
{
    public class Znamka
    {


        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Predmet { get; set; }
        public int Vaha { get; set; }
        public int Hodnoceni { get; set; }
        public double PravaZnamka()
        {
            return Vaha * Hodnoceni;
        }

        public override string ToString()
        {
            return Vaha + " " + Hodnoceni + " " + Predmet;
        }

        public static implicit operator Znamka(string v)
        {
            throw new NotImplementedException();
        }
    }
}
