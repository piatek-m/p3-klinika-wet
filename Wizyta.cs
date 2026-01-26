using System.Text.Json.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Wizyta
    public class Wizyta
    {
        public Wizyta(int id, DateTime data, int idZwierzecia, int idLekarza, string? diagnoza, string? zalecenia, Klinika klinika)
        {
            Id = id;
            Data = data;
            IdZwierzecia = idZwierzecia;
            IdLekarza = idLekarza;
            Diagnoza = diagnoza;
            Zalecenia = zalecenia;
            PrzepisaneLeki = new List<PrzepisanyLek>();
            Klinika = klinika;
        }

        public int Id { get; init; } // Id wizyty
        public DateTime Data { get; init; } // Data wizyty
        public int IdZwierzecia { get; init; } // Id zwierzecia, czyli pacjenta
        public int IdLekarza { get; init; } // Id lekarza prowadzącego wizytę
        public string? Diagnoza { get; init; } // Diagnoza postawiona na wizycie 
        public string? Zalecenia { get; init; } // Zalecenia wystawione na wizycie
        public List<PrzepisanyLek> PrzepisaneLeki { get; init; } // Przepisane na tej wizycie

        [JsonIgnore]
        public Klinika Klinika;


        // Metoda do przepisywania leku
        public void PrzepiszLek(int idLeku, int iloscDni, string dawkowanie)
        {
            // Znajdź lek w bazie kliniki
            var lek = Klinika.Leki.FirstOrDefault(l => l.Id == idLeku);
            if (lek == null)
                throw new ArgumentException("Lek o podanym ID nie istnieje!");

            // Utwórz przepisany lek
            var przepisanyLek = new PrzepisanyLek
            {
                Lek = lek,
                DataPrzepisania = DateTime.Now,
                IloscDni = iloscDni,
                Dawkowanie = dawkowanie
            };

            // SPRAWDŹ KONFLIKTY przed dodaniem
            SprawdzKonflikty(przepisanyLek);

            // Dodaj lek do listy
            PrzepisaneLeki.Add(przepisanyLek);
        }

        // Metoda sprawdzająca konflikty
        private void SprawdzKonflikty(PrzepisanyLek nowyLek)
        {
            if (PrzepisaneLeki == null || PrzepisaneLeki.Count == 0)
                return;

            foreach (var istniejacyLek in PrzepisaneLeki)
            {
                // Sprawdź czy nowy lek koliduje z istniejącym
                if (nowyLek.Lek.KonfliktujaceLeki != null &&
                    nowyLek.Lek.KonfliktujaceLeki.Any(k => k.Id == istniejacyLek.Lek.Id))
                {
                    // Wywolanie eventu
                    var eventArgs = new KonfliktLekowEventArgs(nowyLek, istniejacyLek, this);
                    Klinika.OnKonfliktLekow(eventArgs);
                }
            }
        }
    }
}