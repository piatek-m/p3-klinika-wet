namespace KlinikaWeterynaryjna
{
    // Klasa PrzepisanyLek (asocjacja między Wizyta i Lek)
    public class PrzepisanyLek
    {
        public DateTime DataPrzepisania { get; set; }
        public int IloscDni { get; set; }
        public string Dawkowanie { get; set; }

        public Lek Parent { get; set; }
    }
}
