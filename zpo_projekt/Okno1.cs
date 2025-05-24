using System.Data;

namespace zpo_projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            wczytajWydatki();
        }

        public void wczytajWydatki()
        {
            try
            {
                using var conn = new NpgsqlConnection(DbConfig.ConnString);
                conn.Open();

                string sql = @"
            SELECT 
                w.ilosc       AS Kwota,
                k.nazwa       AS Kategoria,
                w.data        AS ""Data dodania""
            FROM wydatki w
            JOIN kategorie k ON w.kategoria = k.id
            ORDER BY w.data DESC;
        ";

                using var cmd = new NpgsqlCommand(sql, conn);
                using var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                dataGridViewWydatki.DataSource = dt;
                dataGridViewWydatki.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy ładowaniu wydatków: {ex.Message}");
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void info_Click(object sender, EventArgs e)
        {
            Okno2 noweOkno = new Okno2();
            noweOkno.ShowDialog();
            WczytajKategorie();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WczytajKategorie();
        }

        public void WczytajKategorie()
        {
            using var conn = new NpgsqlConnection(DbConfig.ConnString);
            conn.Open();
            string sql = "SELECT id, nazwa FROM kategorie ORDER BY nazwa;";
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);

            kategorieComboBox.DataSource = dt;
            kategorieComboBox.DisplayMember = "nazwa";
            kategorieComboBox.ValueMember = "id";
        }

        private void AddDataToWydatki(int amount, int catId)
        {
            try
            {
                using var conn = new NpgsqlConnection(DbConfig.ConnString);
                conn.Open();

                string sql = @"
                    INSERT INTO wydatki (ilosc, kategoria, data)
                    VALUES (@amount, @catId, NOW());
                ";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("amount", amount);
                cmd.Parameters.AddWithValue("catId", catId);

                int rows = cmd.ExecuteNonQuery();
                wczytajWydatki();
                MessageBox.Show($"Dodano nowy wydatek");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy dodawaniu do bazy: {ex.Message}");
            }
        }


        private void kategorieComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(iloscTextBox.Text, out int kwota))
            {
                MessageBox.Show("Podaj poprawną liczbę w polu Kwota!");
                return;
            }

            if (kategorieComboBox.SelectedValue == null)
            {
                MessageBox.Show("Wybierz kategorię!");
                return;
            }
            int kategoria = (int)kategorieComboBox.SelectedValue;

            AddDataToWydatki(kwota, kategoria);
        }

        private void iloscTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
