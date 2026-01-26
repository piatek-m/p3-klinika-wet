namespace KlinikaWeterynaryjna
{
    public class PrzepisanyLek : Lek
    {
        public DateTime DataPrzepisania { get; init; }
        public int IloscDni { get; set; }
        public string Dawkowanie { get; init; }
        public Lek Lek { get; set; }
    }
}
