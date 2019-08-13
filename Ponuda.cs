using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    [Serializable]
    class Ponuda
    {
        
        private int idAutomobila;
        private DateTime datumOd;
        private DateTime datumDo;
        private double cenaDan;


        public string auto() {
            Automobil n = new Automobil();
            List<Automobil> a = new List<Automobil>();
            a = Datoteke<Automobil>.citanje("automobili.bin");
            for (int i = 0; i < a.Count; i++) {
                if (a[i].ID1 == idAutomobila) { n = a[i]; }
               
            }
            return n.Marka+" " + n.Model +" "
                +n.Godiste;

        }

        public override string ToString()
        {
            return auto()+ " od "+(datumOd.ToShortDateString()).ToString() + " do "+ (datumDo.ToShortDateString()).ToString()+ " cena: "+cenaDan;
        }


        public Ponuda(int idAutomobila, DateTime datumOd, DateTime datumDo, double cenaDan)
        {
            this.idAutomobila = idAutomobila;
            this.datumOd = datumOd;
            this.datumDo = datumDo;
            this.cenaDan = cenaDan;
        }


        public static Ponuda vP(int x,String od, string doo)
        {
            List<Ponuda> ponude = new List<Ponuda>();
            ponude = Datoteke<Ponuda>.citanje("ponude.bin");
            List<Automobil> automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje("automobili.bin");
            int flag = 0;
            for (int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i].IdAutomobila == automobili[x].ID1)
                {
                    if (DateTime.Parse(od) >= ponude[i].DatumOd &&
                        DateTime.Parse(doo) <= ponude[i].DatumDo)
                    {
                        return ponude[i];
                    }

                }
            }
            return null ;

        }

        public static void upisiPonudu(Ponuda p) {
            List<Ponuda> ponude = new List<Ponuda>();
            ponude = Datoteke<Ponuda>.citanje("ponude.bin");
            ponude.Add(p);
            Datoteke<Ponuda>.upis("ponude.bin", ponude);

        }


        public static void izbrisiPonudu(Ponuda p)
        {
            int indeks = 0;
            List<Ponuda> ponude = new List<Ponuda>();
            ponude = Datoteke<Ponuda>.citanje("ponude.bin");
            for (int i = 0; i < ponude.Count; i++)
            {
                if (ponude[i].cenaDan == p.cenaDan
                    && ponude[i].IdAutomobila==p.idAutomobila
                   && DateTime.Parse(ponude[i].datumOd.ToString()) == p.DatumOd
                     && DateTime.Parse(ponude[i].datumDo.ToString()) == p.DatumDo

                    )
                {
                    indeks = i;
                }
            }
            ponude.RemoveAt(indeks);
            Datoteke<Ponuda>.upis("ponude.bin", ponude);

        }
        public Ponuda()
        {
        }

        public int IdAutomobila { get => idAutomobila; set => idAutomobila = value; }
        public DateTime DatumOd { get => datumOd; set => datumOd = value; }
        public DateTime DatumDo { get => datumDo; set => datumDo = value; }
        public double CenaDan { get => cenaDan; set => cenaDan = value; }
    }
}
