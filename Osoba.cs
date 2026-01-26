using System.Text.Json.Serialization;

namespace KlinikaWeterynaryjna
{
    public abstract class Osoba
    {
        public Osoba(int _id, string _imie, string _nazwisko, string? _nrTelefonu, Klinika _klinika)
        => (Id, Imie, Nazwisko, NrTelefonu, Klinika) = (_id, _imie, _nazwisko, _nrTelefonu, _klinika);

        // Id jest stałe
        public int Id { get; init; }

        // Dane osobowe mogą się zmienić
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string? NrTelefonu { get; set; }

        [JsonIgnore]
        public Klinika Klinika { get; set; }
    }
}