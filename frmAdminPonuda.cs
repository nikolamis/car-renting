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
    public partial class frmAdminPonuda : Form
    {
      
        static string putanja = "automobili.bin";
        static string putanjap = "ponude.bin";
        static string putanjar = "rezervacije.bin";

        public frmAdminPonuda()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            List<Ponuda> ponude = new List<Ponuda>();
            ponude = Datoteke<Ponuda>.citanje(putanjap);
            listBox1.HorizontalScrollbar = true;
            listBox1.DataSource = ponude;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Ponuda> ponude = new List<Ponuda>();
            ponude = Datoteke<Ponuda>.citanje(putanjap);

            List<Automobil> automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanja);

            
            int indeks = comboBox1.SelectedIndex;
           
            ponude.Add(new Ponuda(indeks, DateTime.Parse(dateTimePicker1.Text), DateTime.Parse(dateTimePicker2.Text), Double.Parse(textBox2.Text)));
            Datoteke<Ponuda>.upis(putanjap, ponude);
            MessageBox.Show("Uspesno ste dodali ponudu");
            ClearTextBoxes();
            refresh();

        }

        private void frmAdminPonuda_Load(object sender, EventArgs e)
        {
            refresh();
            List<Automobil> automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanja);
            comboBox1.DataSource = automobili;
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
            List<Ponuda> ponude = new List<Ponuda>();
            ponude = Datoteke<Ponuda>.citanje(putanjap);
            List<Rezervacije> rez = new List<Rezervacije>();
            rez = Datoteke<Rezervacije>.citanje(putanjar);
            Rezervacije r = new Rezervacije();



            for (int i = 0; i < ponude.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                    r = new Rezervacije(ponude[i].IdAutomobila, ponude[i].DatumOd, ponude[i].DatumDo, ponude[i].CenaDan);
                    ponude.RemoveAt(i);
                }
            }

            for (int i = 0; i < rez.Count; i++) {
                if (rez[i].IdAutomobila == r.IdAutomobila && rez[i].DatumOd == r.DatumOd && rez[i].DatumDo == r.DatumDo && rez[i].Cena == r.Cena)
                {
                    rez.Remove(rez[i]);
                }

            }

            Datoteke<Rezervacije>.upis(putanjar, rez);
            Datoteke<Ponuda>.upis(putanjap, ponude);
            ClearTextBoxes();
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Ponuda> ponuda = new List<Ponuda>();
            ponuda = Datoteke<Ponuda>.citanje(putanjap);
            Ponuda nasaPonuda = new Ponuda();


            for (int i = 0; i < ponuda.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                    nasaPonuda = ponuda[i];
                    break;

                }
            }

            textBox2.Text = nasaPonuda.CenaDan.ToString();
            dateTimePicker1.Text = nasaPonuda.DatumOd.ToString();
            dateTimePicker2.Text = nasaPonuda.DatumDo.ToString();
            comboBox1.SelectedIndex = nasaPonuda.IdAutomobila;

            

            ponuda.Remove(nasaPonuda);
            Datoteke<Ponuda>.upis(putanjap, ponuda);
            
        }
    }
}
