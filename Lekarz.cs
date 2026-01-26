using System.Data.Common;

namespace KlinikaWeterynaryjna
{

    // Klasa Lekarz
    public class Lekarz : Osoba
    {
        public Lekarz(int _id, string _imie, string _nazwisko, string _nrTelefonu, Klinika _klinika, string? _specjalizacja) : base(_id, _imie, _nazwisko, _nrTelefonu, _klinika)
        {
            if (string.IsNullOrWhiteSpace(NrTelefonu))
                throw new ArgumentException("Numer telefonu lekarza jest wymagany!");

            Specjalizacja = _specjalizacja;
        }


        // Specjalizacja: nie jest wymagana -> nullable
        public string? Specjalizacja { get; set; }

        public List<Wizyta> GetVisits()
        {
            return Klinika.Wizyty.Where(wizyta => wizyta.IdLekarza == Id).ToList();
        }

        // Aktualizowanie danych lekarza
        public void AktualizujDane(string? nowe_Imie = null, string? nowe_Nazwisko = null, string? nowy_NrTelefonu = null, string? nowa_Specjalizacja = null)
        {
            if (nowe_Imie != null && !Walidacja.PoprawnaNazwa(nowe_Imie))
                throw new ArgumentException("Niepoprawne imię");

            if (nowe_Nazwisko != null && !Walidacja.PoprawnaNazwa(nowe_Nazwisko))
                throw new ArgumentException("Niepoprawne nazwisko");

            if (nowy_NrTelefonu != null && !Walidacja.PoprawnyTelefon(nowy_NrTelefonu))
                throw new ArgumentException("Niepoprawny numer");

            if (nowa_Specjalizacja != null && !Walidacja.PoprawnaNazwa(nowa_Specjalizacja))
                throw new ArgumentException("Niepoprawna specjalizacja");

            // Aktualizacja
            if (nowe_Imie != null) Imie = nowe_Imie;
            if (nowe_Nazwisko != null) Nazwisko = nowe_Nazwisko;
            if (nowy_NrTelefonu != null) NrTelefonu = nowy_NrTelefonu;
            if (nowa_Specjalizacja != null) Specjalizacja = nowa_Specjalizacja;
        }
    }
}