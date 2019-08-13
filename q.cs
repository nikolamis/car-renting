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
    public partial class q : Form
    {
        public q()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Kupac> k = Datoteke<Kupac>.citanje("kupci.bin");
            foreach(Kupac x in k)
            {
                MessageBox.Show(x.ToString());
            }
        }
    }
}
