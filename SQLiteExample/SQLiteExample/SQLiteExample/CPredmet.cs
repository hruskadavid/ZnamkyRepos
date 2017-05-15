using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteExample
{
    public class CPredmet
    {
        public string Predmet { get; set; }
        public double Prumer { get; set; }
        public int Znamek { get; set; }
        public int Absence { get; set; }

        public override string ToString()
        {
            return Predmet;
        }
    }
}