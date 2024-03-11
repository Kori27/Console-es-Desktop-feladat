using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvek
{
    internal class Books
    {
        public string sorszam { get; set; }
        public string kategoria { get; set; }
        public string konyv { get; set; }
        public int ar { get; set; } 
        public int db { get; set; } 

        public Books(string sorszam, string kategoria, string konyv, int ar, int db)
        {
            this.sorszam = sorszam;
            this.kategoria = kategoria;
            this.konyv = konyv;
            this.ar = ar;
            this.db = db;
        }
    }
}
