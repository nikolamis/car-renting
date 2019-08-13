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
    public partial class frmAdminRezervacije : Form
    {
        
        String putanjaa = "automobili.bin";
        String putanjak = "kupci.bin";
        String putanjar = "rezervacije.bin";
        String putanjap = "ponude.bin";
        public frmAdminRezervacije()
        {
            InitializeComponent();
        }


        public void refresh() {
            List<Rezervacije> rez = new List<Rezervacije>();
            rez = Datoteke<Rezervacije>.citanje(putanjar);
            listBox1.HorizontalScrollbar = true;
            listBox1.DataSource = rez;
           

        }

        private void frmAdminRezervacije_Load(object sender, EventArgs e)
        {
            List<Automobil> automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanjaa);
            comboBox1.DataSource = automobili;
            List<Kupac> kupci = new List<Kupac>();

            kupci = Datoteke<Kupac>.citanje(putanjak);
            comboBox2.DataSource = kupci;
            refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



       

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) {
                MessageBox.Show("morate uneti sve podatke");
            }
            else if (Ponuda.vP(comboBox1.SelectedIndex, dateTimePicker1.Text, dateTimePicker2.Text) !=null) {

                List<Ponuda> ponude = new List<Ponuda>();
                ponude = Datoteke<Ponuda>.citanje("ponude.bin");
                Ponuda ponudaZaIzmenu = Ponuda.vP(comboBox1.SelectedIndex, dateTimePicker1.Text, dateTimePicker2.Text);
                //ponudaZaIzmenu je ponuda koja odgovara ovom kupcu, u tom rasponu je vreme kad njemu odgovara da iznajmi auto
                //dva slucaja postoje, ako hoce od samog datuma da iznajmi, u tom slucaju brisem ovu ponudu iz ponuda
                //i dodajem novu ponudu od kraja njegovog iznajmljivanja do kraja dostupnosti 
                //
                //drugi slucaj je ako hoce neki period izmedju 
                //u tom slucaju pravim dve nove ponude od datuma kad je automobil slobodan do datuma kad gospodin zeli da iznajmi
                //i od kraja njegovog iznajmiljivanja do samog kraja
                //
                //treci slucaj je ako hoce puno vreme da ga iznajmi , u tom slucaju samo brisem ponudu 

                if (DateTime.Parse(dateTimePicker1.Text) == ponudaZaIzmenu.DatumOd
                    && DateTime.Parse(dateTimePicker2.Text) == ponudaZaIzmenu.DatumDo
                    )
                {
                    Ponuda.izbrisiPonudu(ponudaZaIzmenu);
                    upisiRez();
                }
                else if (DateTime.Parse(dateTimePicker1.Text) == ponudaZaIzmenu.DatumOd
                    && DateTime.Parse(dateTimePicker2.Text) < ponudaZaIzmenu.DatumDo
                    && DateTime.Parse(dateTimePicker2.Text)>ponudaZaIzmenu.DatumOd
                    )

                {
                    Ponuda p = new Ponuda(comboBox1.SelectedIndex, DateTime.Parse(dateTimePicker2.Text), ponudaZaIzmenu.DatumDo, ponudaZaIzmenu.CenaDan);
                    Ponuda.izbrisiPonudu(ponudaZaIzmenu);
                    Ponuda.upisiPonudu(p);
                    
                    upisiRez();
                }
                else if (DateTime.Parse(dateTimePicker1.Text) > ponudaZaIzmenu.DatumOd
                     && DateTime.Parse(dateTimePicker2.Text) == ponudaZaIzmenu.DatumDo
                     && (DateTime.Parse(dateTimePicker1.Text)< ponudaZaIzmenu.DatumDo
                     ))
                {
                    Ponuda p = new Ponuda(comboBox1.SelectedIndex, ponudaZaIzmenu.DatumOd, DateTime.Parse(dateTimePicker1.Text), ponudaZaIzmenu.CenaDan);
                    Ponuda.izbrisiPonudu(ponudaZaIzmenu);
                    Ponuda.upisiPonudu(p);
                    upisiRez();
                }
                else if (DateTime.Parse(dateTimePicker1.Text) > ponudaZaIzmenu.DatumOd
                     && DateTime.Parse(dateTimePicker2.Text) < ponudaZaIzmenu.DatumDo
                     && DateTime.Parse(dateTimePicker1.Text)< ponudaZaIzmenu.DatumDo
                     && DateTime.Parse(dateTimePicker2.Text)> DateTime.Parse(dateTimePicker1.Text)

                     ) {

                    Ponuda p = new Ponuda(comboBox1.SelectedIndex, ponudaZaIzmenu.DatumOd, DateTime.Parse(dateTimePicker1.Text), ponudaZaIzmenu.CenaDan);
                    Ponuda p2 = new Ponuda(comboBox1.SelectedIndex, DateTime.Parse(dateTimePicker2.Text), ponudaZaIzmenu.DatumDo, ponudaZaIzmenu.CenaDan);

                    Ponuda.izbrisiPonudu(ponudaZaIzmenu);
                    Ponuda.upisiPonudu(p);
                    Ponuda.upisiPonudu(p2);
                    
                    upisiRez();

                }
                else
                {
                    MessageBox.Show("nije dostupan termin");
                }


                    
            }



            else
            {
                MessageBox.Show("automobil nije dostupan u izabranom terminu");
            }
        }
        public void upisiRez() {
            List<Rezervacije> rez = new List<Rezervacije>();
            rez = Datoteke<Rezervacije>.citanje(putanjar);
            rez.Add(new Rezervacije(comboBox1.SelectedIndex, comboBox2.SelectedIndex + 1, DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text), Double.Parse(textBox1.Text)));
            Datoteke<Rezervacije>.upis(putanjar, rez);

            refresh();
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
        private void button3_Click(object sender, EventArgs e)
        {
            List<Rezervacije> rez = new List<Rezervacije>();
            rez = Datoteke<Rezervacije>.citanje(putanjar);
            Ponuda p=new Ponuda();
            List<Ponuda> pon = new List<Ponuda>();
            pon = Datoteke<Ponuda>.citanje(putanjap);
            for (int i = 0; i < rez.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                     p = new Ponuda(rez[i].IdAutomobila, rez[i].DatumOd, rez[i].DatumDo, rez[i].Cena);
                    rez.RemoveAt(i); 
                }
            }


            
            pon.Add(p);

            Datoteke<Ponuda>.upis(putanjap, pon);
            Datoteke<Rezervacije>.upis(putanjar, rez);
            ClearTextBoxes();
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Rezervacije> rezervacije = new List<Rezervacije>();
            rezervacije = Datoteke<Rezervacije>.citanje(putanjar);
            Rezervacije rez = new Rezervacije();


            for (int i = 0; i < rezervacije.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                    rez = rezervacije[i];
                }
            }

            textBox1.Text = rez.Cena.ToString();
            dateTimePicker1.Text = rez.DatumOd.ToString();
            dateTimePicker2.Text = rez.DatumDo.ToString();
            comboBox1.SelectedIndex = rez.IdAutomobila;
            comboBox2.SelectedIndex = rez.IdKupca-1;


            rezervacije.Remove(rez);
            Datoteke<Rezervacije>.upis(putanjar, rezervacije);
        }

        
    }
}
