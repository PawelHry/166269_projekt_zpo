using System.ComponentModel;
using System.Linq;
using zpo_projekt;

namespace zpo_projekt
{
    public partial class Form1 : Form
    {
        private readonly RepozytoriumKategoriiPg _repoKategorie = new();
        private readonly RepozytoriumWydatkowPg _repoWydatki = new();

        private List<Kategoria> _listaKategorii = new();
        private BindingList<Wydatek> _listaWydatkow = new();

        private bool _kasujemy = false;

        public Form1()
        {
            InitializeComponent();

            WczytajKategorie();
            OdswiezSiatke();

            dataGridViewWydatki.CellContentClick += Grid_CellClick;
        }

        private void WczytajKategorie()
        {
            _listaKategorii = _repoKategorie.PobierzWszystkie().ToList();
            kategorieComboBox.DataSource = _listaKategorii;
            kategorieComboBox.DisplayMember = "Nazwa";
            kategorieComboBox.ValueMember = "Id";
        }


        private void OdswiezSiatke()
        {
            _listaWydatkow = new BindingList<Wydatek>(
                _repoWydatki.PobierzWszystkie().ToList());

            dataGridViewWydatki.DataSource = _listaWydatkow;

            if (!dataGridViewWydatki.Columns.Contains("Usun"))
            {
                dataGridViewWydatki.Columns["Id"].Visible = false;
                dataGridViewWydatki.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Usun",
                    Text = "Usun",
                    UseColumnTextForButtonValue = true
                });
            }

            AktualizujSume();
        }

        private void AktualizujSume()
        {
            decimal suma = _listaWydatkow.Sum(w => w.Kwota);
            sumaLabel.Text = $"Suma wydatków: {suma:C}";
        }
        private void btnDodaj_Click(object sender, EventArgs e)
        {
            decimal kwota = kwotaNumeric.Value;
            if (kwota < 0.01M)
            {
                MessageBox.Show("Kwota musi być większa od zera!");
                return;
            }

            if (kategorieComboBox.SelectedItem is not Kategoria kat)
            {
                MessageBox.Show("Wybierz kategorię!");
                return;
            }

            _repoWydatki.Dodaj(new Wydatek
            {
                Kwota = kwota,
                Data = DateTime.Now,
                KategoriaId = kat.Id,
                Kategoria = kat
            });

            kwotaNumeric.Value = 0;
            OdswiezSiatke();
        }
        private void Grid_CellClick(object? s, DataGridViewCellEventArgs e)
        {
            if (_kasujemy) return;
            if (e.RowIndex < 0) return;
            if (dataGridViewWydatki.Columns[e.ColumnIndex].Name != "Usun") return;
            if (e.RowIndex >= _listaWydatkow.Count) return;

            var wyd = _listaWydatkow[e.RowIndex];

            if (MessageBox.Show($"Usunąć wydatek «{wyd}»?",
                                "Potwierdź",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _kasujemy = true;
            try
            {
                _repoWydatki.Usun(wyd.Id);
                _listaWydatkow.RemoveAt(e.RowIndex);
                dataGridViewWydatki.CurrentCell = null;
                AktualizujSume();
            }
            finally
            {
                BeginInvoke(() => _kasujemy = false);
            }
        }

        private void btnFiltruj_Click(object sender, EventArgs e)
        {
            if (kategorieComboBox.SelectedItem is not Kategoria kat) return;

            var filtr = _listaWydatkow
                .Where(x => x.KategoriaId == kat.Id)
                .ToList();

            dataGridViewWydatki.DataSource = new BindingList<Wydatek>(filtr);
            AktualizujSume();
        }

        private void btnWszystkie_Click(object sender, EventArgs e)
        {
            OdswiezSiatke();
        }

        private void btnKategorie_Click(object? s, EventArgs e)
        {
            using var okno = new Okno2();
            okno.KategorieZmienione += (_, __) =>
            {
                WczytajKategorie();
                OdswiezSiatke();
            };
            okno.ShowDialog(this);
            WczytajKategorie();
        }
    }
}
