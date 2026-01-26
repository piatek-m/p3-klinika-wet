using System.Text.Json.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Zwierzę
    public class Zwierze
    {
        public Zwierze(int _id, string _imie, string _gatunek, Klinika _klinika, DateTime? _dataUrodzenia = null)
        => (Id, Imie, Gatunek, Klinika, DataUrodzenia, Wlasciciele) = (_id, _imie, _gatunek, _klinika, _dataUrodzenia, []);

        #region Properties

        // Id i gatunek: init, nie powinny się zmieniać 
        public int Id { get; init; }
        public string Gatunek { get; init; }

        // Imię może się zmienić
        public string Imie { get; set; }

        // Data urodzenia: opcjonalna, może być zmieniona/uzupełniona
        public DateTime? DataUrodzenia { get; set; }

        // Lista właścicieli: zwierzę może mieć wielu właścicieli
        public List<int> Wlasciciele { get; set; }

        // Relacja: zwierzę ma wiele aktywnych leków
        public List<PrzepisanyLek>? AktywneLeki { get; set; } = new();

        [JsonIgnore]
        public Klinika Klinika { get; set; }
        // Konstruktor bez parametrów dla JSONa
        public Zwierze()
        {
            Wlasciciele = [];
        }

        #endregion

        #region Methods

        // Aktualizowanie danych zwierzęcia
        public void AktualizujDane(string? nowe_Imie = null, string? nowa_DataUrodzenia = null)
        {
            if (nowe_Imie != null && !Walidacja.PoprawnaNazwa(nowe_Imie))
                throw new ArgumentException("Niepoprawne imię");

            // Parsowanie daty z stringa
            DateTime? parsowanaData = null;
            if (nowa_DataUrodzenia != null)
            {
                if (!DateTime.TryParse(nowa_DataUrodzenia, out DateTime wynik))
                    throw new ArgumentException("Niepoprawny format daty");

                parsowanaData = wynik;
            }

            // Jeżeli którekolwiek dane nie są null to są zmieniane
            if (nowe_Imie != null)
                Imie = nowe_Imie;

            if (nowa_DataUrodzenia != null)
                DataUrodzenia = parsowanaData;
        }

        // Dodawanie właściciela
        public void PrzypiszWlasciciela(int idWlasciciela)
        {
            var wlasciciel = Klinika.Wlasciciele.FirstOrDefault(w => w.Id == idWlasciciela);

            if (wlasciciel == null)
                throw new ArgumentException("Właściciel o tym ID nie istnieje");

            if (!Wlasciciele.Contains(idWlasciciela))
                Wlasciciele.Add(idWlasciciela);
        }

        // Usuwanie właściciela
        public void UsunWlasciciela(int idWlasciciela)
        {
            Wlasciciele?.Remove(idWlasciciela);
        }

        public List<Wizyta> GetVisits()
        {
            return Klinika.Wizyty
                .Where(wizyta => wizyta.IdZwierzecia == Id)
                .ToList();
        }

        #endregion
    }
}