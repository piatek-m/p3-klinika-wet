namespace KlinikaWeterynaryjna
{
    // Klasa Właściciel
    public class Wlasciciel
    {
        public Wlasciciel(int id_Wlasciciela, string imie_Wlasciciela, string nazwisko_Wlasciciela) => (Id, Imie, Nazwisko) = (id_Wlasciciela, imie_Wlasciciela, nazwisko_Wlasciciela);

        public int Id { get; init; }
        public string Imie { get; init; }
        public string Nazwisko { get; init; }
        public string? NrTelefonu { get; set; }
        public string? Email { get; set; }

        // Relacja: właściciel ma wiele zwierząt (0..n)
        public List<Zwierze>? Zwierzeta { get; set; }

        public Wlasciciel()
        {
            Zwierzeta = new List<Zwierze>();
        }

        public List<Zwierze> GetAnimals()
        {
            return Zwierzeta;
        }
    }
}