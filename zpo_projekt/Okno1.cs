namespace zpo_projekt
{
    public partial class Form1 : Form
    {
        private const string ConnString =
         "Host=localhost;Port=5432;Database=zpo_projekt;Username=postgres;Password=admin";

        public Form1()
        {
            InitializeComponent();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void info_Click(object sender, EventArgs e)
        {
            Okno2 noweOkno = new Okno2();
            noweOkno.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using var conn = new NpgsqlConnection(ConnString);
            conn.Open();

            string sql = "SELECT id, nazwa FROM kategorie ORDER BY nazwa;";
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            var dt = new System.Data.DataTable();
            dt.Load(reader);

            kategorieComboBox.DataSource = dt;
            kategorieComboBox.DisplayMember = "nazwa";
            kategorieComboBox.ValueMember = "id";
        }

        private void AddDataToWydatki(int amount, int catId)
        {
            try
            {
                using var conn = new NpgsqlConnection(ConnString);
                conn.Open();

                string sql = @"
                    INSERT INTO wydatki (ilosc, kategoria, data)
                    VALUES (@amount, @catId, NOW());
                ";

                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("amount", amount);
                cmd.Parameters.AddWithValue("catId", catId);

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show($"Dodano {rows} wydatek(ów) 🎉");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy dodawaniu do bazy: {ex.Message}");
            }
        }


        private void kategorieComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
