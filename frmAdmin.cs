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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAdminRezervacije f = new frmAdminRezervacije();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdminAutomobili f = new frmAdminAutomobili();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAdminKupac f = new frmAdminKupac();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAdminPonuda f = new frmAdminPonuda();
            f.Show();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
