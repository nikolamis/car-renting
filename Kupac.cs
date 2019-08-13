using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    [Serializable]

    
    class Kupac : Korisnik
    {

        static int id = 0;
        private int ID;
        private String ime;
        private String prezime;
        private long jmbg;
        private DateTime datumRodjenja;
        private String telefon;
        static Kupac k;
       
        public Kupac(string username, string password) : base(username, password)
        {
        }

        public Kupac(string ime, string prezime, long jmbg, DateTime datumRodjenja, string telefon, string username, string password) : base(username, password)
        {
            ID = ++id;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.datumRodjenja = datumRodjenja;
            this.telefon = telefon;
        }

        public Kupac()
        {
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public long Jmbg { get => jmbg; set => jmbg = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Telefon { get => telefon; set => telefon = value; }


        public static void postaviKupca(string x, string y)
        {
            k = new Kupac(x, y);


        }
        public static Kupac vratiKupca()
        {
            List<Kupac> korisnici = new List<Kupac>();
            korisnici = Datoteke<Kupac>.citanje("kupci.bin");
            foreach (Kupac z in korisnici)
            {
                if (z.Username == k.Username)
                {
                    k =z;
                }
            }
            return k;

        }

        public static Kupac proveri3(List<Kupac> list, string u,string p)
        {
            foreach (Kupac k in list)
            {
                if (k.Username == u && k.Password==p)
                {
                    return k;
                }
            }
            return null;
        }

        public static Kupac proveri2(List<Kupac> list, string u)
        {
            foreach (Kupac k in list)
            {
                if (k.Username==u)
                {
                    return k;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return ime + " " + prezime + " " + jmbg + " " + (datumRodjenja.ToShortDateString()).ToString() + " " + telefon;
        }
    }
}
