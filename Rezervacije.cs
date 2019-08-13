using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    [Serializable]
    class Rezervacije
    {
        
        private int idAutomobila;
        private int idKupca;
        private DateTime datumOd;
        private DateTime datumDo;
        private double cena;
        public Rezervacije(int idAutomobila, DateTime datumOd, DateTime datumDo, double cena)
        {
            this.idAutomobila = idAutomobila;
       
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cena = cena;
        }
        public Rezervacije(int idAutomobila, int idKupca, DateTime datumOd, DateTime datumDo, double cena)
        {
            this.idAutomobila = idAutomobila;
            this.idKupca = idKupca;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cena = cena;
        }

        public Rezervacije()
        {
        }

        public int IdAutomobila { get => idAutomobila; set => idAutomobila = value; }
        public int IdKupca { get => idKupca; set => idKupca = value; }
        public DateTime DatumOd { get => datumOd; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo; set => datumDo = value; }
        public double Cena { get => cena; set => cena = value; }

        public static List<Rezervacije> izbrisiRezervaciju(List<Rezervacije> lista, int indeks)
        {
            try
            {
                lista.RemoveAt(indeks);
                
            }
            catch (Exception ex) {
            }
            return lista;
        }

        public Kupac vratiK() {
            List<Kupac> l = new List<Kupac>();
            l = Datoteke<Kupac>.citanje("kupci.bin");
            Kupac k = new Kupac();
            for (int i = 0; i < l.Count; i++) {
                if (l[i].ID1 == IdKupca)
                {
                    k = l[i];
                }
            }
            return k;
        }
        public Automobil vratiA() {
            List<Automobil> l = new List<Automobil>();
            l = Datoteke<Automobil>.citanje("automobili.bin");
            Automobil a = new Automobil();
            for (int i = 0; i < l.Count; i++) {
                if (l[i].ID1 == idAutomobila) { a = l[i]; }
            }
            return a;

        }


        public override string ToString()
        {
            return vratiK().Ime+" "+vratiK().Prezime +" "+vratiA().Marka+" "+vratiA().Model +" od "+(DatumOd.ToShortDateString()).ToString()+" do "+ (DatumDo.ToShortDateString()).ToString() + " cena:"+cena+"din";
        }

    }
}
