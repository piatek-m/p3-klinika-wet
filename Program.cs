using KlinikaWeterynaryjna;

class Program
{
    static void Main(string[] args)
    {
        Klinika klinika = new Klinika();

        klinika.DodajLekarza("Jan", "Kowalski", "123456789", "Kardiologia");
        klinika.DodajWlasciciela("Anna", "Nowak", "987654321");
        klinika.DodajZwierze("Burek", "Pies", new DateTime(2020, 5, 15));

        // zapis 
        klinika.ZapiszDoPlikow();

        // odczyt
        Klinika? wczytanaKlinika = Klinika.WczytajZPlikow();

        if (wczytanaKlinika != null)
        {
            Console.WriteLine($"Liczba lekarzy: {wczytanaKlinika.Lekarze.Count}");
            Console.WriteLine($"Liczba zwierząt: {wczytanaKlinika.Zwierzeta.Count}");

            foreach (var zwierze in wczytanaKlinika.Zwierzeta)
            {
                Console.WriteLine($"- {zwierze.Imie} ({zwierze.Gatunek})");
            }
        }
    }
}