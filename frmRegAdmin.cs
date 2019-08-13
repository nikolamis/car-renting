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
    public partial class frmRegAdmin : Form
    {
        static string putanja = "korisnici.bin";
        public frmRegAdmin()
        {
            InitializeComponent();
        }

        private void frmRegAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici = Datoteke<Korisnik>.citanje(putanja);
            Korisnik logovanje = Korisnik.proveri2(korisnici, textBox1.Text);


            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("morate uneti podatke");
            }
            else if (logovanje != null)
            {
                MessageBox.Show("korisnik postoji");
            }
            else
            {
                korisnici.Add(new Administrator(textBox1.Text, textBox2.Text));
                Datoteke<Korisnik>.upis(putanja, korisnici);
                MessageBox.Show("uspesno si se registrovao");
               

            }
        }
    }
}
