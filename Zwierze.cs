namespace KlinikaWeterynaryjna
{
    // Klasa Zwierzę
    public class Zwierze
    {
        public Zwierze(int _id, string _imie, string _gatunek, DateTime? _dataUrodzenia = null, List<int>? _idWlasciciela = null)
        => (Id, Imie, Gatunek, DataUrodzenia, IdWlasciciela) = (_id, _imie, _gatunek, _dataUrodzenia, _idWlasciciela ?? []);

        #region Properties

        // Id i gatunek: init, nie powinny się zmieniać 
        public int Id { get; init; }
        public string Gatunek { get; init; }

        // Imię może się zmienić
        public string Imie { get; set; }

        // Data urodzenia: opcjonalna, może być zmieniona/uzupełniona
        public DateTime? DataUrodzenia { get; set; }

        // Lista właścicieli: zwierzę może mieć wielu właścicieli
        public List<int>? IdWlasciciela { get; set; }

        // Relacja: zwierzę ma wiele aktywnych leków
        public List<PrzepisanyLek>? AktywneLeki { get; set; } = new();

        public Klinika Klinika { get; set; }

        #endregion

        #region Methods

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

        #endregion
    }
}