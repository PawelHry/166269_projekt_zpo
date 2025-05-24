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
            dodajKategorie(nowaKategoria);
        }

        private void dodajKategorie(string nazwa)
        {
                using var conn = new NpgsqlConnection(DbConfig.ConnString);
                conn.Open();

                string sql = @"
                    INSERT INTO kategorie (nazwa)
                    VALUES (@nazwa);
                ";
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("nazwa", nazwa);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Dodano nowe kategorie");
                this.Close();
        }

        private void dodajKategorieTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
