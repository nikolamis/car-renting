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


    public partial class frmRegKupac : Form
    {

        static string putanja = "kupci.bin";
        public frmRegKupac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Kupac> korisnici = new List<Kupac>();
            korisnici = Datoteke<Kupac>.citanje(putanja);
            Kupac logovanje = Kupac.proveri2(korisnici, textBox5.Text);

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 ||
                textBox3.Text.Length == 0 || textBox4.Text.Length == 0 ||
                    textBox5.Text.Length == 0 || textBox6.Text.Length == 0 ||
                    dateTimePicker1.Text.Length == 0)
            { //proveri ovo za datetimepicker
                MessageBox.Show("niste uneli sve podatke");
            }
            else if (logovanje != null)
            { MessageBox.Show("korisnik sa tim username-om postoji"); }
            else
            {
                korisnici.Add(new Kupac(
                    textBox1.Text, textBox2.Text, (long)Convert.ToDouble(textBox3.Text), DateTime.Parse(dateTimePicker1.Text), textBox4.Text,textBox5.Text, textBox6.Text));
                Datoteke<Kupac>.upis(putanja, korisnici);
                MessageBox.Show("uspesno si se registrovao");
                
            }

        }

        private void frmRegKupac_Load(object sender, EventArgs e)
        {

        }
    }
}
