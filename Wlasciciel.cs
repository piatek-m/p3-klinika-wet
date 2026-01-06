using System.Diagnostics.CodeAnalysis;

namespace KlinikaWeterynaryjna
{
    // Klasa Właściciel
    public class Wlasciciel
    {
        [SetsRequiredMembers]
        public Wlasciciel(int Id, string Imie, string Nazwisko) => (Id, Imie, Nazwisko) = (Id, Imie, Nazwisko);

        public required int Id { get; init; }
        public required string Imie { get; init; }
        public required string Nazwisko { get; init; }
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