namespace KlinikaWeterynaryjna
{
    // Klasa PrzepisanyLek (asocjacja między Wizyta i Lek)
    public class PrzepisanyLek : Lek
    {
        public DateTime DataPrzepisania { get; init; }
        public int IloscDni { get; set; }
        public string Dawkowanie { get; init; }

        public Lek Parent { get; set; }
    }
}
