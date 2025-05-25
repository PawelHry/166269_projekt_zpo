using System.Text.Json;

namespace zpo_projekt;
public sealed class Konfiguracja
{
    private static readonly Lazy<Konfiguracja> _instancja =
        new(() => Wczytaj("config.json"));

    public static Konfiguracja Instancja => _instancja.Value;

    public string CiągPołączenia { get; init; } = string.Empty;

    private Konfiguracja() { }

    private static Konfiguracja Wczytaj(string plik)
    {
        var json = File.ReadAllText(plik);
        var root = JsonSerializer.Deserialize<JsonElement>(json);

        return new Konfiguracja
        {
            CiągPołączenia = root
                .GetProperty("Polaczenie")
                .GetProperty("Postgres")
                .GetString()!
        };
    }
}
