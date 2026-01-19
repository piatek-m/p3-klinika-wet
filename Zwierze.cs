namespace KlinikaWeterynaryjna
{
    // Klasa Zwierzę
    public class Zwierze
    {
        public Zwierze(int id_Zwierzecia, string imie_Zwierzecia, string gatunek_Zwierzecia, DateTime? dataUrodzenia_Zwierzecia = null, List<int>? idWlasciciela_Zwierzecia = null) => (Id, Imie, Gatunek, DataUrodzenia, IdWlasciciela) = (id_Zwierzecia, imie_Zwierzecia, gatunek_Zwierzecia, dataUrodzenia_Zwierzecia, idWlasciciela_Zwierzecia ?? new List<int>());

        // Id zwierzęcia: init, nie powinno się zmieniać
        public int Id { get; init; }

        // Imię może się zmienić
        public string Imie { get; set; }
        public string Gatunek { get; init; }

        // Data urodzenia: opcjonalna, może być zmieniona/uzupełniona
        public DateTime? DataUrodzenia { get; set; }

        // Lista właścicieli: zwierzę może mieć wielu właścicieli
        public List<int>? IdWlasciciela { get; set; }

        // Relacja: zwierzę ma wiele aktywnych leków
        public List<PrzepisanyLek>? AktywneLeki { get; set; } = new();

        public Klinika? Klinika { get; set; }


        // Aktualizowanie danych zwierzęcia
        public void AktualizujDane(string? nowe_Imie = null, DateTime? nowa_DataUrodzenia = null)
        {
            // Jeżeli którekolwiek dane nie są null to są zmieniane
            if (nowe_Imie != null)
                Imie = nowe_Imie;

            if (nowa_DataUrodzenia != null)
                DataUrodzenia = nowa_DataUrodzenia;
        }

        // Dodawanie właściciela
        public void DodajWlasciciela(int idWlasciciela)
        {
            if (IdWlasciciela == null)
                IdWlasciciela = new List<int>();

            if (!IdWlasciciela.Contains(idWlasciciela))
                IdWlasciciela.Add(idWlasciciela);
        }

        // Usuwanie właściciela
        public void UsunWlasciciela(int idWlasciciela)
        {
            IdWlasciciela?.Remove(idWlasciciela);
        }

        public List<Wizyta> GetVisits()
        {
            return Klinika.Wizyty
                .Where(wizyta => wizyta.IdZwierzecia == Id)
                .ToList();
        }
    }
}