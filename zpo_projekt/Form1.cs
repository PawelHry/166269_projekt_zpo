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

        }

        private void AddDataToWydatki(int amount, int catId) 
        {

        }
    }
}
