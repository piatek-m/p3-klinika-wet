namespace KlinikaWeterynaryjna
{
    // Klasa przechowująca informacje o konflikcie
    public class KonfliktLekowEventArgs : EventArgs
    {
        public PrzepisanyLek Lek1 { get; set; }
        public PrzepisanyLek Lek2 { get; set; }
        public Wizyta Wizyta { get; set; }
        public string Komunikat { get; set; }

        public KonfliktLekowEventArgs(PrzepisanyLek lek1, PrzepisanyLek lek2, Wizyta wizyta)
        {
            Lek1 = lek1;
            Lek2 = lek2;
            Wizyta = wizyta;
            Komunikat = $"Wykryto konflikt między {lek1.Nazwa} a {lek2.Nazwa}!";
        }
    }
}