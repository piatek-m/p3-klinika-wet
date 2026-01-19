namespace KlinikaWeterynaryjna
{
    // Klasa Lek - lista leków, które klinika ma w bazie, potrzebne do automatycznego wykrywania konfliktów
    public class Lek
    {
        public Lek(int _id, string _nazwa)
        => (Id, Nazwa) = (_id, _nazwa);

        public int Id { get; init; }
        public string Nazwa { get; init; }

        // Relacja: lek może mieć konflikty z innymi lekami
        public List<Lek>? KonfliktujaceLeki { get; set; }

        public Lek()
        {
            KonfliktujaceLeki = new List<Lek>();
        }
    }

}