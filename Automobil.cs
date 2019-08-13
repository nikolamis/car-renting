using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prviProjekatDrugiPut
{
    [Serializable]
    class Automobil
    {
        static int id=0;
        private int ID;
        private String marka;
        private String model;
        private int godiste;
        private int kubikaza;
        private String pogon;
        private String vrstaMenjaca;
        private String karoserija;
        private String gorivo;
        private int brojVrata;

        public Automobil()
        {
            ID = ++id;
        }

        public int pazOvo() {
            List<Automobil> a = new List<Automobil>();
            a = Datoteke<Automobil>.citanje("automobili.bin");
            int indeks=-1;
            foreach (Automobil k in a) {
                indeks = k.ID1;
            }
            indeks+= 1;
            return indeks;
        }



        public Automobil(string marka, string model, int godiste, int kubikaza, string pogon, string vrstaMenjaca, string karoserija, string gorivo, int brojVrata)
        {
            ID = pazOvo();
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brojVrata = brojVrata;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public int Godiste { get => godiste; set => godiste = value; }
        public int Kubikaza { get => kubikaza; set => kubikaza = value; }
        public string Pogon { get => pogon; set => pogon = value; }
        public string VrstaMenjaca { get => vrstaMenjaca; set => vrstaMenjaca = value; }
        public string Karoserija { get => karoserija; set => karoserija = value; }
        public string Gorivo { get => gorivo; set => gorivo = value; }
        public int BrojVrata { get => brojVrata; set => brojVrata = value; }

        public override string ToString()
        {
            return  marka + " " + model + " " + godiste + " " + kubikaza+"kv" +" pogon "+pogon+" "+ vrstaMenjaca+ " "+karoserija;
        }

        public string ispis2() {
            return marka + " " + model + " " + godiste;
        }

    }
}
