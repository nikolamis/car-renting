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
    public partial class frmAdminKupac : Form
    {
        static string putanjak = "kupci.bin";
        List<Kupac> korisnici;


        public frmAdminKupac()

        {

            InitializeComponent();
        }


        public void ubaciulistu()

        {


           
            List<Kupac> kupac = new List<Kupac>();
            kupac = Datoteke<Kupac>.citanje(putanjak);
            listBox1.HorizontalScrollbar = true;
            //listBox1.Items.Clear();
            listBox1.DataSource = kupac;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            korisnici = new List<Kupac>();
            korisnici = Datoteke<Kupac>.citanje(putanjak);
            Kupac logovanje = Kupac.proveri2(korisnici, textBox6.Text);


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
                korisnici.Add(new Kupac(textBox1.Text, textBox2.Text, (long)Convert.ToDouble(textBox3.Text), DateTime.Parse(dateTimePicker1.Text), textBox4.Text, textBox5.Text, textBox6.Text));
                Datoteke<Kupac>.upis(putanjak, korisnici);
                MessageBox.Show("uspesno si dodao kupca");
                ClearTextBoxes();
                ubaciulistu();
            }
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }
        private void frmAdminKupac_Load(object sender, EventArgs e)
        {

            ubaciulistu();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(korisnici[listBox1.SelectedIndex].Username.ToString());
            korisnici = new List<Kupac>();           
            korisnici = Datoteke<Kupac>.citanje(putanjak);
            Kupac nasKupac = new Kupac();
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                    nasKupac = korisnici[i];
                }

            }

            ClearTextBoxes();
           //OVDE NESTO

            textBox1.Text = nasKupac.Ime;
            textBox2.Text = nasKupac.Prezime;
            textBox3.Text = nasKupac.Jmbg.ToString();
            textBox4.Text = nasKupac.Telefon;
            dateTimePicker1.Text = nasKupac.DatumRodjenja.ToString() ;
            textBox5.Text = nasKupac.Username;
            textBox6.Text = nasKupac.Password;

            korisnici.Remove(nasKupac);
            Datoteke<Kupac>.upis(putanjak, korisnici);
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.SelectedIndex
            korisnici = new List<Kupac>();
           
            korisnici = Datoteke<Kupac>.citanje(putanjak);
           
            for(int i=0;i< korisnici.Count; i++) {
                if (i == listBox1.SelectedIndex)
                {
                    korisnici.RemoveAt(i);
                }

            }
            Datoteke<Kupac>.upis(putanjak, korisnici);
            ubaciulistu();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            korisnici = new List<Kupac>();
            korisnici = Datoteke<Kupac>.citanje(putanjak);
            Kupac nasKupac = new Kupac();
            for (int i = 0; i < korisnici.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                    nasKupac = korisnici[i];
                }

            }
            MessageBox.Show(nasKupac.Ime);
            textBox1.Text = nasKupac.Ime;
            textBox2.Text = nasKupac.Prezime;
            textBox3.Text = nasKupac.Jmbg.ToString();
            textBox4.Text = nasKupac.Telefon;
            dateTimePicker1.Text = nasKupac.DatumRodjenja.ToString();
            textBox5.Text = nasKupac.Username;
            textBox6.Text = nasKupac.Password;

            korisnici.Remove(nasKupac);
            Datoteke<Kupac>.upis(putanjak, korisnici);
            
        }
    }
}
