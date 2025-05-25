using System.ComponentModel;
using zpo_projekt;

namespace zpo_projekt
{
    public partial class Okno2 : Form
    {
        private readonly RepozytoriumKategoriiPg _repo = new();
        private BindingList<Kategoria> _lista = new();
        public event EventHandler? KategorieZmienione;
        private void PodnieśZdarzenie() =>
            KategorieZmienione?.Invoke(this, EventArgs.Empty);

        private bool _kasujemy = false;

        public Okno2()
        {
            InitializeComponent();
            Load += (_, _) => Załaduj();
            dataGridViewKategorie.CellContentClick += Grid_CellClick;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string nazwa = dodajKategorieTextBox.Text.Trim();
            if (nazwa.Length == 0) return;

            var nowa = _repo.Dodaj(new Kategoria { Nazwa = nazwa });
            dodajKategorieTextBox.Clear();

            _lista.Add(nowa);
            PodnieśZdarzenie();
        }

        private void Załaduj()
        {
            _lista = new BindingList<Kategoria>(_repo.PobierzWszystkie().ToList());
            dataGridViewKategorie.DataSource = _lista;

            if (!dataGridViewKategorie.Columns.Contains("Usuń"))
            {
                dataGridViewKategorie.Columns["Id"].Visible = false;
                dataGridViewKategorie.Columns.Add(new DataGridViewButtonColumn
                {
                    Name = "Usuń",
                    Text = "Usuń",
                    UseColumnTextForButtonValue = true
                });
            }
        }

        private void Grid_CellClick(object? s, DataGridViewCellEventArgs e)
        {
            if (_kasujemy) return;
            if (e.RowIndex < 0) return;
            if (dataGridViewKategorie.Columns[e.ColumnIndex].Name != "Usuń") return;
            if (e.RowIndex >= _lista.Count) return;

            var kat = _lista[e.RowIndex];

            if (MessageBox.Show(
                    $"Usunąć kategorię «{kat.Nazwa}»?\n(Znikną jej wydatki)",
                    "Potwierdź",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            _kasujemy = true;
            try
            {
                _repo.Usuń(kat.Id);
                _lista.RemoveAt(e.RowIndex);
                dataGridViewKategorie.CurrentCell = null;
                PodnieśZdarzenie();
            }
            finally
            {
                BeginInvoke(() => _kasujemy = false);
            }
        }
    }
}
