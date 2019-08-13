using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prviProjekatDrugiPut
{
    public partial class frmRezervacija : Form
    {
        List<Automobil> automobili;
        List<String> marke;
        List<String> modeli;
        List<int> godista;
        List<int> kubikaze;
        List<String> karoserije;
        List<int> vrata;




        public frmRezervacija()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmRezervacija_Load(object sender, EventArgs e)
        {
             automobili = Datoteke<Automobil>.citanje("automobili.bin");
             marke = new List<string>();
            foreach (Automobil x in automobili) {
                marke.Add(x.Marka);
            }
            comboBox1.DataSource = marke;

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                       
            String marka = marke[comboBox1.SelectedIndex];
            
            modeli = new List<string>();
            foreach (Automobil x in automobili)
            {
                if (x.Marka == marka)
                    modeli.Add(x.Model);
            }
            comboBox4.DataSource = modeli;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            int godiste = godista[comboBox7.SelectedIndex];
            kubikaze = new List<int>();
            foreach (Automobil x in automobili)
            {
                if (x.Godiste == godiste)
                    kubikaze.Add(x.Kubikaza);
            }
            comboBox2.DataSource = kubikaze;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            String model = modeli[comboBox4.SelectedIndex];
            godista = new List<int>();
            foreach (Automobil x in automobili)
            {
                if (x.Model == model)
                    godista.Add(x.Godiste);
            }
            comboBox7.DataSource = godista;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            String karoserija = karoserije[comboBox2.SelectedIndex];
            vrata = new List<int>();
            foreach (Automobil x in automobili)
            {
                if (x.Karoserija == karoserija)
                    vrata.Add(x.BrojVrata);
            }
            comboBox8.DataSource = vrata;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kubikaza = kubikaze[comboBox2.SelectedIndex];
            karoserije = new List<String>();
            foreach (Automobil x in automobili)
            {
                if (x.Kubikaza == kubikaza)
                    karoserije.Add(x.Karoserija);
            }
            comboBox5.DataSource = karoserije;
        }
    }
}
