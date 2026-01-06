namespace KlinikaWeterynaryjna
{
    // Klasa Lek
    public class Lek
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        // Relacja: lek może mieć konflikty z innymi lekami
        public List<Lek> KonfliktujaceLeki { get; set; }

        public Lek()
        {
            KonfliktujaceLeki = new List<Lek>();
        }
    }

}