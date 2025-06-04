using System.Text.Json;

namespace zpo_projekt
{
    /// <summary>
    ///  Singleton zwracający ciąg połączenia do bazy.
    ///  Odczyt z pliku config.json (kopiowany do katalogu wyjściowego).
    /// </summary>
    public sealed class Konfiguracja
    {
        private static readonly Lazy<Konfiguracja> _instancja =
            new(() => Wczytaj("config.json"));

        public static Konfiguracja Instancja => _instancja.Value;

        public string CiagPolaczenia { get; init; } = string.Empty;

        private Konfiguracja() { }

        /* ---------- prywatne ---------- */
        private static Konfiguracja Wczytaj(string nazwaPliku)
        {
            string sciezka = Path.Combine(AppContext.BaseDirectory, nazwaPliku);
            var json = File.ReadAllText(sciezka);
            var root = JsonSerializer.Deserialize<JsonElement>(json);

            return new Konfiguracja
            {
                CiagPolaczenia = root
                    .GetProperty("Polaczenie")
                    .GetProperty("Postgres")
                    .GetString()!
            };
        }
    }
}
