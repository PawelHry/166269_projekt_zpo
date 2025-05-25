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

        private void Okno2_Load(object sender, EventArgs e)
        {
            WczytajKategorie();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void WczytajKategorie()
        {
            try
            {
                using var conn = new NpgsqlConnection(DbConfig.ConnString);
                conn.Open();

                string sql = @"
            SELECT id, nazwa
            FROM kategorie
            ORDER BY nazwa;
        ";

                using var cmd = new NpgsqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                dataGridViewKategorie.DataSource = dt;
                dataGridViewKategorie.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy ładowaniu kategorii: {ex.Message}");
            }
        }

    }
}
