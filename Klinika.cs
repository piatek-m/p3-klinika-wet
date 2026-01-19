using System.Text.Json;

namespace KlinikaWeterynaryjna
{
    // Klasa Klinika
    public class Klinika
    {
        // Listy obiektów
        // Z getterami, ale bez setterów, aby nie dało się znullować listy (klinika.Zwierzeta = null)

        public List<Wlasciciel> Wlasciciele { get; } // Klienci, czyli właściciele zwierząt
        public List<Zwierze> Zwierzeta { get; } // Z
        public List<Wizyta> Wizyty { get; } // Zarejestrowane wizyty (odbyte i jeszcze nie odbyte)
        public List<Lekarz> Lekarze { get; } // Lekarze pracujący w klinice
        public List<Lek> Leki { get; } // Znane leki, które można wypisać

        public Klinika()
        {
            Wlasciciele = new List<Wlasciciel>();
            Zwierzeta = new List<Zwierze>();
            Wizyty = new List<Wizyta>();
            Lekarze = new List<Lekarz>();
            Leki = new List<Lek>();
        }

        // Dodawanie lekarza
        public void DodajLekarz(string imie_Lekarza, string nazwisko_Lekarza, string nrTelefonu_Lekarza, string specjalizacja_Lekarza)
        {
            // Ustawienie Id: największe id+1, w przypadku 
            int id_Lekarza = Lekarze.Max(lekarz => lekarz.Id) + 1;

            // Walidacja
            if (string.IsNullOrWhiteSpace(imie_Lekarza))
                throw new ArgumentException("Imię nie może być puste!");

            if (string.IsNullOrWhiteSpace(nrTelefonu_Lekarza))
                throw new ArgumentException("Numer telefonu nie może być pusty!");

            if (string.IsNullOrWhiteSpace(specjalizacja_Lekarza))
                throw new ArgumentException("Specjalizacja nie może być pusta!");

            // Tworzenie obiektu lekarz
            Lekarz nowyLekarz = new Lekarz(id_Lekarza, imie_Lekarza, nazwisko_Lekarza, nrTelefonu_Lekarza, specjalizacja_Lekarza)
            {
                Klinika = this
            };

            // Dodanie do listy
            Lekarze.Add(nowyLekarz);
        }

        // Dodawanie Zwierzecia
        public void DodajZwierze(string imie_Zwierzecia, string gatunek_Zwierzecia, DateTime? dataUrodzenia_Zwierzecia, List<int>? idWlasciciela = null)
        {
            // Ustawienie Id: największe id+1, w przypadku 
            int id_Zwierzecia = Zwierzeta.Max(Zwierze => Zwierze.Id) + 1;

            // Walidacja
            if (string.IsNullOrWhiteSpace(imie_Zwierzecia))
                throw new ArgumentException("Imię nie może być puste!");

            if (idWlasciciela != null)
            {
                foreach (var idWlasc in idWlasciciela)
                {
                    if (!Wlasciciele.Any(wlasciciel => wlasciciel.Id == idWlasc))
                        throw new ArgumentException($"Właściciel o ID {idWlasc} nie istnieje!");
                }
            }

            // Tworzenie obiektu Zwierze
            Zwierze noweZwierze = new Zwierze(id_Zwierzecia, imie_Zwierzecia, gatunek_Zwierzecia, dataUrodzenia_Zwierzecia, idWlasciciela)
            {
                Klinika = this
            };

            // Dodanie do listy
            Zwierzeta.Add(noweZwierze);
        }

        // Dodawanie wizyty
        public void DodajWizyte(int id_Wizyty, DateTime data_Wizyty, int id_Zwierzecia, int id_Lekarza)
        {
            // Walidacja

            // Any() = does *any* element meet the requirements?
            // Wewnątrz lamba: parameter => function body

            // Czy Zwierzę o podanym Id istnieje
            if (!Zwierzeta.Any(zwierze => zwierze.Id == id_Zwierzecia))
                throw new ArgumentException("Zwierzę o podanym ID nie istnieje!");

            // Czy Lekraz o podanym Id istnieje
            if (!Lekarze.Any(lekarz => lekarz.Id == id_Lekarza))
                throw new ArgumentException("Lekarz o podanym ID nie istnieje!");

            // Czy Id wizyty jest unikalne
            if (Wizyty.Any(wizyta => wizyta.Id == id_Wizyty))
                throw new ArgumentException("Już istnieje wizyta o tym samym ID!");


            // Tworzenie wizyty i dodanie jej do listy

            // Utworzona wizyta
            Wizyta wizyta = new Wizyta
            {
                Id = id_Wizyty,
                Data = data_Wizyty,
                IdZwierzecia = id_Zwierzecia,
                IdLekarza = id_Lekarza
            };
            // Dodanie wizyty do listy
            Wizyty.Add(wizyta);
        }

        // Wyszukiwanie zwierząt
        public List<Zwierze> WyszukajZwierzeta(string? imie_Podane = null, string? gatunek_Podany = null)
        {
            // Filtrowanie Zwierząt: najpierw po imieniu, potem po gatunku

            var wynikWstepny = new List<Zwierze>(); // Wynik filtrowania po imieniu

            // 1. Filtr: po imieniu, bez LINQ
            foreach (Zwierze z in Zwierzeta)
            {
                // Czy Podane Imię jest puste
                if (string.IsNullOrEmpty(imie_Podane))
                {
                    wynikWstepny.Add(z);
                    continue; // Pominięcie dalszego sprawdzania imion - wszystkie pasują
                }

                // Czy imię sprawdzanego zwierzęcia NIE jest null oraz czy zawiera Imię Podane
                if (!string.IsNullOrEmpty(z.Imie) && z.Imie.ToLower().Contains(imie_Podane.ToLower()))
                {
                    wynikWstepny.Add(z);
                }
            }

            // 2. Filtr: po gatunku, używa LINQ
            var wynik =
                from z in wynikWstepny
                where
                // Warunki jak w 1. filtrze
                    string.IsNullOrEmpty(gatunek_Podany)
                    || z.Gatunek.ToLower().Contains(gatunek_Podany.ToLower())
                select z;

            // Można jeszcze użyć WHERE z lambdą

            return wynik.ToList();
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