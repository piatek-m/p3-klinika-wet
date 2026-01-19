namespace KlinikaWeterynaryjna
{
    // Klasa Właściciel
    public class Wlasciciel : Osoba
    {
        public Wlasciciel(int _id, string _imie, string _nazwisko, string? _nrTelefonu, Klinika _klinika) : base(_id, _imie, _nazwisko, _nrTelefonu, _klinika)
        {
            ZwierzetaWlasciciela = [];
            // to samo co: 
            // Zwierzeta = new List<Zwierze>();
        }

        // Relacja: właściciel ma wiele zwierząt (0..n)
        public List<Zwierze> ZwierzetaWlasciciela { get; set; }

        public void PrzypiszZwierze(int IdZwierzecia)
        {
            var zwierze = Klinika.Zwierzeta.FirstOrDefault(z => z.Id == IdZwierzecia);

            if (zwierze == null)
                throw new ArgumentException("Zwierzę o tym ID nie istnieje");

            ZwierzetaWlasciciela.Add(zwierze);
        }

        public List<Zwierze> GetAnimals()
        {
            return ZwierzetaWlasciciela;
        }
    }
}