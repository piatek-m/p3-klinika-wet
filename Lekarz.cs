namespace KlinikaWeterynaryjna
{

    // Klasa Lekarz
    public class Lekarz
    {
        public Lekarz(int id_Lekarza, string imie_Lekarza, string nazwisko_Lekarza, string nrTelefonu_Lekarza, string? specjalizacja_Lekarza) => (Id, Imie, Nazwisko, NrTelefonu, Specjalizacja) = (id_Lekarza, imie_Lekarza, nazwisko_Lekarza, nrTelefonu_Lekarza, specjalizacja_Lekarza);

        // Id lekarza: init, id nie powinno się zmieniać
        public int Id { get; init; }

        // Dane osobowe: mogą się zmienić
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }

        // Specjalizacja: nie jest wymagana -> nullable
        public string? Specjalizacja { get; set; }

        public Klinika Klinika { get; set; }

        public List<Wizyta> GetVisits()
        {
            return Klinika.Wizyty.Where(wizyta => wizyta.IdLekarza == Id).ToList();
        }

        // Aktualizowanie danych lekarza
        public void AktualizujDane(string? nowe_Imie = null, string? nowe_Nazwisko = null, string? nowy_NrTelefonu = null, string? nowa_Specjalizacja = null)
        {
            // Jeżeli którekolwiek dane nie są null to są zmieniane

            if (nowe_Imie != null)
                Imie = nowe_Imie;

            if (nowe_Nazwisko != null)
                Nazwisko = nowe_Nazwisko;

            if (nowy_NrTelefonu != null)
                NrTelefonu = nowy_NrTelefonu;

            if (nowa_Specjalizacja != null)
                Specjalizacja = nowa_Specjalizacja;

        }
    }
}