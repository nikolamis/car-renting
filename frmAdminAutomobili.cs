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


    public partial class frmAdminAutomobili : Form
    {
        static string putanja = "automobili.bin";
        List<Automobil> automobili;
        public frmAdminAutomobili()
        {
            InitializeComponent();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void refresuj()
        {
            automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanja);
            listBox1.DataSource = automobili;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanja);

            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 ||
                textBox3.Text.Length == 0 || textBox4.Text.Length == 0 ||
                    textBox5.Text.Length == 0 || textBox6.Text.Length == 0 ||
                    textBox7.Text.Length == 0 || textBox8.Text.Length == 0 ||
                textBox9.Text.Length == 0)
            {
                MessageBox.Show("niste uneli sve podatke");
            }
            else
            {
                automobili.Add(new Automobil(textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text), textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, Int32.Parse(textBox9.Text)));
                Datoteke<Automobil>.upis(putanja, automobili);
                MessageBox.Show("uspesno si dodao automobil");
                ClearTextBoxes();
                refresuj();

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

        private void frmAdminAutomobili_Load(object sender, EventArgs e)
        {
            refresuj();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanja);

            for(int i = 0; i < automobili.Count; i++){
                if (i == listBox1.SelectedIndex) {
                    automobili.RemoveAt(i);
                }
            }
            Datoteke<Automobil>.upis(putanja, automobili);
            ClearTextBoxes();
            refresuj();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            automobili = new List<Automobil>();
            automobili = Datoteke<Automobil>.citanje(putanja);
            Automobil nasAuto = new Automobil();

                 
            for (int i = 0; i < automobili.Count; i++)
            {
                if (i == listBox1.SelectedIndex)
                {
                    nasAuto = automobili[i];
                    
                }
            }

            textBox1.Text = nasAuto.Marka;
            textBox2.Text = nasAuto.Model;
            textBox3.Text = nasAuto.Godiste.ToString();
            textBox4.Text = nasAuto.Kubikaza.ToString();
            textBox5.Text = nasAuto.Pogon;
            textBox6.Text = nasAuto.VrstaMenjaca;
            textBox7.Text = nasAuto.Karoserija;
            textBox8.Text = nasAuto.Gorivo;
            textBox9.Text =(nasAuto.BrojVrata).ToString();

            automobili.Remove(nasAuto);
            Datoteke<Automobil>.upis(putanja, automobili);


        }
    }
}
