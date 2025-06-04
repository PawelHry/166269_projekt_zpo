using Npgsql;

namespace zpo_projekt
{
    public class RepozytoriumKategoriiPg : IRepozytorium<Kategoria>
    {
        private readonly string _conn = Konfiguracja.Instancja.CiagPolaczenia;

        public Kategoria Dodaj(Kategoria kat)
        {
            const string sql = "INSERT INTO kategorie (nazwa) VALUES (@n) RETURNING id;";
            using var conn = new NpgsqlConnection(_conn);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("n", kat.Nazwa);

            kat.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return kat;
        }

        public IEnumerable<Kategoria> PobierzWszystkie()
        {
            const string sql = "SELECT id, nazwa FROM kategorie ORDER BY nazwa;";
            using var conn = new NpgsqlConnection(_conn);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                yield return new Kategoria
                {
                    Id = rdr.GetInt32(0),
                    Nazwa = rdr.GetString(1)
                };
            }
        }

        public void Usun(int id)
        {
            const string sql = "DELETE FROM kategorie WHERE id = @id;";
            using var conn = new NpgsqlConnection(_conn);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public class RepozytoriumWydatkowPg : IRepozytorium<Wydatek>
    {
        private readonly string _conn = Konfiguracja.Instancja.CiagPolaczenia;

        public Wydatek Dodaj(Wydatek w)
        {
            const string sql = @"
                INSERT INTO wydatki (ilosc, kategoria, data)
                VALUES (@kw, @kat, @dt) RETURNING id;";
            using var conn = new NpgsqlConnection(_conn);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("kw", w.Kwota);
            cmd.Parameters.AddWithValue("kat", w.KategoriaId);
            cmd.Parameters.AddWithValue("dt", w.Data);

            w.Id = Convert.ToInt32(cmd.ExecuteScalar());
            return w;
        }

        public IEnumerable<Wydatek> PobierzWszystkie()
        {
            const string sql = @"
                SELECT w.id, w.ilosc, w.data,
                       k.id   AS kid,
                       k.nazwa
                FROM wydatki w
                JOIN kategorie k ON w.kategoria = k.id
                ORDER BY w.data DESC;";
            using var conn = new NpgsqlConnection(_conn);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var kat = new Kategoria
                {
                    Id = rdr.GetInt32(3),
                    Nazwa = rdr.GetString(4)
                };

                yield return new Wydatek
                {
                    Id = rdr.GetInt32(0),
                    Kwota = rdr.GetDecimal(1),
                    Data = rdr.GetDateTime(2),
                    KategoriaId = kat.Id,
                    Kategoria = kat
                };
            }
        }

        public void Usun(int id)
        {
            const string sql = "DELETE FROM wydatki WHERE id = @id;";
            using var conn = new NpgsqlConnection(_conn);
            conn.Open();

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
