namespace KlinikaWeterynaryjna
{

    // Klasa Lekarz
    public class Lekarz
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }
        public string Specjalizacja { get; set; }

        public List<Wizyta> GetVisits()
        {
            // Metoda do pobierania wizyt lekarza
            return new List<Wizyta>();
        }
    }
}