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
    public partial class frmKupac : Form
    {


        static string putanjar = "rezervacije.bin";
        static string putanjap = "ponude.bin";
        List<Rezervacije> pom = new List<Rezervacije>();
        Kupac k;
        public frmKupac()
        {
            InitializeComponent();
        }

        private void frmKupac_Load(object sender, EventArgs e)
        {
            k = Kupac.vratiKupca();
            
            
            List<Rezervacije> rezervacije = new List<Rezervacije>();

            rezervacije = Datoteke<Rezervacije>.citanje(putanjar);
            foreach (Rezervacije r in rezervacije)
            {
                if (r.IdKupca == k.ID1)
                {
                    pom.Add(r);
                }

            }


            refreshuj();
        }

        private void refreshuj() {
            listBox1.HorizontalScrollbar = true;
            pom = Datoteke<Rezervacije>.citanje(putanjar);
            listBox1.DataSource = pom;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            List<Rezervacije> rez = new List<Rezervacije>();
            rez = Datoteke<Rezervacije>.citanje(putanjar);
            Ponuda p = new Ponuda();
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

            refreshuj();



            /*Rezervacije.izbrisiRezervaciju(pom, listBox1.SelectedIndex);
            Datoteke<Rezervacije>.upis(putanjar, pom);
            refreshuj();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRezervacija f = new frmRezervacija();
            f.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
