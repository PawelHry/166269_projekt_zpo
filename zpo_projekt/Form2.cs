using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zpo_projekt
{
    public partial class Okno2 : Form
    {
        public Okno2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nowaKategoria = dodajKategorieTextBox.Text.Trim();


        }

        private void dodajKategorieTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
