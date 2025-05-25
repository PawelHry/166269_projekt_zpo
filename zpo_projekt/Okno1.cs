using System.ComponentModel;
using System.Linq;
using zpo_projekt;

namespace zpo_projekt
{
    public partial class Form1 : Form
    {
        private readonly RepozytoriumKategoriiPg _katRepo = new();
        private readonly RepozytoriumWydatkówPg _wydRepo = new();

        private List<Kategoria> _kategorie = new();
        private BindingList<Wydatek> _lista = new();

        public Form1()
        {
            InitializeComponent();
            WczytajKategorie();
            OdświeżSiatkę();
            dataGridViewWydatki.CellContentClick += Grid_CellClick;
        }
        private void WczytajKategorie()
        {
            _kategorie = _katRepo.PobierzWszystkie().ToList();
            kategorieComboBox.DataSource = _kategorie;
            kategorieComboBox.DisplayMember = "Nazwa";
            kategorieComboBox.ValueMember = "Id";
        }
        private void OdświeżSiatkę()
        {
            _lista = new BindingList<Wydatek>(_wydRepo.PobierzWszystkie().ToList());
            dataGridViewWydatki.DataSource = _lista;

            if (!dataGridViewWydatki.Columns.Contains("Usuń"))
            {
                dataGridViewWydatki.Columns["Id"].Visible = false;
                var btn = new DataGridViewButtonColumn
                {
                    Name = "Usuń",
                    Text = "Usuń",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewWydatki.Columns.Add(btn);
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            decimal kwota = kwotaNumeric.Value;

            if (kwota <= 0)
            {
                MessageBox.Show("Kwota musi być większa od zera!");
                return;
            }

            if (kategorieComboBox.SelectedItem is not Kategoria kat)
            {
                MessageBox.Show("Wybierz kategorię!");
                return;
            }

            _wydRepo.Dodaj(new Wydatek
            {
                Kwota = kwota,
                Data = DateTime.Now,
                KategoriaId = kat.Id,
                Kategoria = kat
            });

            kwotaNumeric.Value = 0;
            OdświeżSiatkę();
        }

        private void Grid_CellClick(object? s, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridViewWydatki.Columns[e.ColumnIndex].Name != "Usuń") return;
            if (e.RowIndex >= _lista.Count) return;

            var wydatek = _lista[e.RowIndex];

            if (MessageBox.Show($"Usunąć wydatek «{wydatek}»?",
                                "Potwierdź",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            dataGridViewWydatki.CellContentClick -= Grid_CellClick;
            try
            {
                _wydRepo.Usuń(wydatek.Id);
                _lista.RemoveAt(e.RowIndex);
                dataGridViewWydatki.CurrentCell = null;
            }
            finally
            {
                dataGridViewWydatki.CellContentClick += Grid_CellClick;
            }
        }

        private void btnFiltruj_Click(object sender, EventArgs e)
        {
            if (kategorieComboBox.SelectedItem is not Kategoria kat) return;
            var filtr = _lista.Where(x => x.KategoriaId == kat.Id).ToList();
            dataGridViewWydatki.DataSource = new BindingList<Wydatek>(filtr);
        }

        private void btnKategorie_Click(object? s, EventArgs e)
        {
            using var okno = new Okno2();
            okno.KategorieZmienione += (_, __) =>
            {
                WczytajKategorie();
                OdświeżSiatkę();
            };
            okno.ShowDialog(this);
            WczytajKategorie();
        }

        private void btnWszystkie_Click(object sender, EventArgs e) => OdświeżSiatkę();

        private void iloscTextBox_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
