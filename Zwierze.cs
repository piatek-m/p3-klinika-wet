using System.Diagnostics.CodeAnalysis;

namespace KlinikaWeterynaryjna
{
    // Klasa Zwierzę
    public class Zwierze
    {
        [SetsRequiredMembers]
        public Zwierze(int Id, string Imie, string Gatunek) => (Id, Imie, Gatunek) = (Id, Imie, Gatunek);
        public required int Id { get; init; }
        public required sbyte Imie { get; init; }
        public required string Gatunek { get; init; }
        public DateTime? DataUrodzenia { get; set; }
        public required List<int>? IdWlasciciela { get; set; }

        // Relacja: zwierzę ma wiele aktywnych leków
        public List<PrzepisanyLek>? AktywneLeki { get; set; } = new();

        public Zwierze()
        {
            AktywneLeki = new List<PrzepisanyLek>();
        }

        public List<Wizyta> GetVisits()
        {
            // Metoda do pobierania wizyt zwierzęcia
            return new List<Wizyta>();
        }
    }
}