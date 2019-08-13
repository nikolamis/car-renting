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
    public partial class Logovanje : Form
    {
        static string putanja = "korisnici.bin";
        static string putanjak = "kupci.bin";
        public Logovanje()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Logovanje_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici = Datoteke<Korisnik>.citanje(putanja);
            Korisnik logovanje = Korisnik.proveri(korisnici,textBox1.Text, textBox2.Text);

            List<Kupac> kupci = new List<Kupac>();
            kupci = Datoteke<Kupac>.citanje(putanjak);
            Kupac log = Kupac.proveri3(kupci, textBox1.Text, textBox2.Text);


                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
                {
                    MessageBox.Show("morate uneti sve podatke");
                }
                else if (logovanje != null)
                {

                    if (logovanje.GetType() == typeof(Administrator))
                    {

                        frmAdmin f = new frmAdmin();

                        f.Show();
                    Hide();

                } }
                else if (log != null)
                {
                    //ako se loguje korisnik, bitno mi je koji korisnik tako da najbolje da posaljem info
                    //o korisniku da bi dalje mogao da pristupim njegovim atributima
                    Kupac.postaviKupca(textBox1.Text, textBox2.Text);
                    frmKupac f = new frmKupac();
                    f.Show();
                Hide();

            
                 
            }
            else
            {
                MessageBox.Show("pogresni podaci");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            frmRegAdmin f = new frmRegAdmin();
            f.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRegKupac f = new frmRegKupac();
            f.Show();
        }

       
    }
}
