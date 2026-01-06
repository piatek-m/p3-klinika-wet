using System.Text.Json;

namespace KlinikaWeterynaryjna
{
    // Klasa Klinika
    public class Klinika
    {
        public List<Wlasciciel> Wlasciciele { get; set; }
        public List<Zwierze> Zwierzeta { get; set; }
        public List<Wizyta> Wizyty { get; set; }
        public List<Lekarz> Lekarze { get; set; }
        public List<Lek> Leki { get; set; }

        public Klinika()
        {
            Wlasciciele = new List<Wlasciciel>();
            Zwierzeta = new List<Zwierze>();
            Wizyty = new List<Wizyta>();
            Lekarze = new List<Lekarz>();
            Leki = new List<Lek>();
        }

        // Metody z diagramu
        public void DodajWizyte()
        {
            // Implementacja dodawania wizyty
        }

        public void WyszukajZwierzeta()
        {
            // Implementacja wyszukiwania zwierząt
        }

        public void ZapiszDoPlikow()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            File.WriteAllText("klinika.json", JsonSerializer.Serialize(this, options));
        }


        public static Klinika WczytajZPlikow()
        {
            var json = File.ReadAllText("klinika.json");
            return JsonSerializer.Deserialize<Klinika>(json);
        }


        // Eventy
        public event EventHandler KonfliktLekow;
        public event EventHandler PrzypomnienieWizyty;
    }
}