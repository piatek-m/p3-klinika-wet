using System.Text.Json.Serialization;

namespace KlinikaWeterynaryjna
{
    // Klasa Właściciel
    public class Wlasciciel : Osoba
    {
        public Wlasciciel(int _id, string _imie, string _nazwisko, string? _nrTelefonu, Klinika _klinika) : base(_id, _imie, _nazwisko, _nrTelefonu, _klinika)
        {
            Zwierzeta = [];
            // to samo co: 
            // Zwierzeta = new List<>();
        }

        // Relacja: właściciel ma wiele zwierząt (0..n)
        public List<int> Zwierzeta { get; set; }

        public void PrzypiszZwierze(int IdZwierzecia)
        {
            var zwierze = Klinika.Zwierzeta.FirstOrDefault(z => z.Id == IdZwierzecia);

            if (zwierze == null)
                throw new ArgumentException("Zwierzę o tym ID nie istnieje");

            if (!Zwierzeta.Contains(IdZwierzecia))
                Zwierzeta.Add(IdZwierzecia);

            Zwierzeta.Add(IdZwierzecia);
        }

        public void AktualizujDane(string? nowe_Imie = null, string? nowe_Nazwisko = null, string? nowy_NrTelefonu = null)
        {
            if (nowe_Imie != null && !Walidacja.PoprawnaNazwa(nowe_Imie))
                throw new ArgumentException("Niepoprawne imię");

            if (nowe_Nazwisko != null && !Walidacja.PoprawnaNazwa(nowe_Nazwisko))
                throw new ArgumentException("Niepoprawne nazwisko");

            if (nowy_NrTelefonu != null && !Walidacja.PoprawnyTelefon(nowy_NrTelefonu))
                throw new ArgumentException("Niepoprawny numer");

            // Aktualizacja
            if (nowe_Imie != null) Imie = nowe_Imie;
            if (nowe_Nazwisko != null) Nazwisko = nowe_Nazwisko;
            if (nowy_NrTelefonu != null) NrTelefonu = nowy_NrTelefonu;
        }

        public List<int> GetAnimals()
        {
            return Zwierzeta;
        }
    }
}