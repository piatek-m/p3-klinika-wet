using System.Data.Common;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace KlinikaWeterynaryjna
{
    // Klasa Klinika
    public class Klinika
    {
        // Listy obiektów
        // Z getterami, ale bez setterów, aby nie dało się znullować listy (klinika.Zwierzeta = null)

        public List<Wlasciciel> Wlasciciele { get; } // Klienci, czyli właściciele zwierząt
        public List<Zwierze> Zwierzeta { get; } // Zwierzęta
        public List<Wizyta> Wizyty { get; } // Zarejestrowane wizyty (odbyte i jeszcze nie odbyte)
        public List<Lekarz> Lekarze { get; } // Lekarze pracujący w klinice
        public List<Lek> Leki { get; } // Znane leki, które można wypisać

        public Klinika()
        {
            Wlasciciele = [];
            Zwierzeta = [];
            Wizyty = [];
            Lekarze = [];
            Leki = [];
            // to samo: 
            // Leki = new List<Lek>()
        }

        #region Dodawanie obiektów

        public void DodajWlasciciela(string imie, string nazwisko, string? nrTelefonu)
        {
            // Walidacja
            if (!Walidacja.PoprawnaNazwa(imie))
                throw new ArgumentException("Niepoprawne imię");
            if (!Walidacja.PoprawnaNazwa(nazwisko))
                throw new ArgumentException("Niepoprawne nazwisko");
            if (nrTelefonu != null && !Walidacja.PoprawnyTelefon(nrTelefonu))
                throw new ArgumentException("Niepoprawny numer");

            int id = Wlasciciele.Count == 0 ? 1 : Wlasciciele.Max(w => w.Id) + 1;

            Wlasciciel nowy = new(id, imie, nazwisko, nrTelefonu, this);

            Wlasciciele.Add(nowy);
        }

        // Dodawanie lekarza
        public void DodajLekarza(string _imie, string _nazwisko, string _nrTelefonu, string? _specjalizacja = null)
        {
            // Walidacja
            if (!Walidacja.PoprawnaNazwa(_imie))
                throw new ArgumentException("Niepoprawne imię");
            if (!Walidacja.PoprawnaNazwa(_nazwisko))
                throw new ArgumentException("Niepoprawne nazwisko");
            if (!Walidacja.PoprawnyTelefon(_nrTelefonu))
                throw new ArgumentException("Niepoprawny numer");

            // Ustawienie Id: największe id+1 
            int _id = Lekarze.Count == 0 ? 1 : Lekarze.Max(lekarz => lekarz.Id) + 1;
            // Tworzenie obiektu lekarz
            Lekarz nowyLekarz = new(_id, _imie, _nazwisko, _nrTelefonu, this, _specjalizacja);

            // Dodanie do listy
            Lekarze.Add(nowyLekarz);
        }

        // Dodawanie Zwierzecia
        public void DodajZwierze(string imie_Zwierzecia, string gatunek_Zwierzecia, DateTime? dataUrodzenia_Zwierzecia, List<int>? idWlasciciela = null)
        {

            // Walidacja
            if (!Walidacja.PoprawnaNazwa(imie_Zwierzecia))
                throw new ArgumentException("Niepoprawne imię");


            if (idWlasciciela != null)
            {
                foreach (var idWlasc in idWlasciciela)
                {
                    if (!Wlasciciele.Any(wlasciciel => wlasciciel.Id == idWlasc))
                        throw new ArgumentException($"Właściciel o ID {idWlasc} nie istnieje!");
                }
            }

            // Ustawienie Id: największe id+1
            int id_Zwierzecia = Zwierzeta.Count == 0 ? 1 : Zwierzeta.Max(zwierze => zwierze.Id) + 1;

            // Tworzenie obiektu Zwierze
            Zwierze noweZwierze = new Zwierze(id_Zwierzecia, imie_Zwierzecia, gatunek_Zwierzecia, this, dataUrodzenia_Zwierzecia);

            // Dodanie do listy
            Zwierzeta.Add(noweZwierze);
        }

        // Dodawanie wizyty
        public void DodajWizyte(DateTime data_Wizyty, int id_Zwierzecia, int id_Lekarza, string? diagnoza, string? zalecenia)
        {
            // Ustawienie Id: największe id+1 
            int id_Wizyty = Wizyty.Count == 0 ? 1 : Wizyty.Max(w => w.Id) + 1;

            // Walidacja

            // Any() = does *any* element meet the requirements?
            // Wewnątrz lambda: parameter => function body
            // weź obiekt zwierze => sprawdź czy zwierze.Id == id_Zwierzecia?

            // Czy Zwierzę o podanym Id istnieje
            if (!Zwierzeta.Any(zwierze => zwierze.Id == id_Zwierzecia))
                throw new ArgumentException("Zwierzę o podanym ID nie istnieje!");

            // Czy Lekraz o podanym Id istnieje
            if (!Lekarze.Any(lekarz => lekarz.Id == id_Lekarza))
                throw new ArgumentException("Lekarz o podanym ID nie istnieje!");

            // Tworzenie wizyty i dodanie jej do listy

            // Utworzona wizyta
            Wizyta nowaWizyta = new Wizyta(id_Wizyty, data_Wizyty, id_Zwierzecia, id_Lekarza, diagnoza, zalecenia, this);
            // Dodanie wizyty do listy
            Wizyty.Add(nowaWizyta);
        }

        #endregion

        #region Wyszukiwanie obiektów

        // Generyczne wyszukiwanie osoby
        public List<T> WyszukajOsobe<T>(List<T> lista, string? imie = null, string? nazwisko = null) where T : Osoba
        {
            var wynik =
               from o in lista
               where
                   (string.IsNullOrEmpty(imie)
                   || o.Imie.Contains(imie, StringComparison.OrdinalIgnoreCase))
                   &&
                   (string.IsNullOrEmpty(nazwisko)
                   || o.Nazwisko.Contains(nazwisko, StringComparison.OrdinalIgnoreCase))
               select o;

            return wynik.ToList();
        }

        // Wyszukiwanie Właściciela, wrapper dla WyszukajOsobe
        public List<Wlasciciel> WyszukajWlasciciela(string? imie = null, string? nazwisko = null)
        {
            return WyszukajOsobe(Wlasciciele, imie, nazwisko);
        }

        // Wyszukiwanie Lekarza, wrapper dla WyszukajOsobe
        public List<Lekarz> WyszukajLekarza(string? imie = null, string? nazwisko = null)
        {
            return WyszukajOsobe(Lekarze, imie, nazwisko);
        }

        // Wyszukiwanie zwierząt
        public List<Zwierze> WyszukajZwierzeta(string? imieSzukane = null, string? gatunekSzukany = null)
        {
            // Filtrowanie Zwierząt: najpierw po imieniu, potem po gatunku

            var wynikWstepny = new List<Zwierze>(); // Wynik filtrowania po imieniu

            // 1. Filtr: po imieniu
            foreach (Zwierze z in Zwierzeta)
            {
                // Czy Podane Imię jest puste
                if (string.IsNullOrEmpty(imieSzukane))
                {
                    wynikWstepny.Add(z);
                    continue; // Pominięcie dalszego sprawdzania imion - wszystkie pasują
                }

                // Czy imię sprawdzanego zwierzęcia NIE jest null oraz czy zawiera Imię Podane
                // StringComparison.OrdinalIgnoreCase zamiast .ToLower(), aby nie tworzyć nowego stringa
                if (!string.IsNullOrEmpty(z.Imie) && z.Imie.Contains(imieSzukane, StringComparison.OrdinalIgnoreCase))
                {
                    wynikWstepny.Add(z);
                }
            }

            // 2. Filtr: po gatunku
            var wynik =
                from z in wynikWstepny
                where
                // Warunki jak w 1. filtrze
                    string.IsNullOrEmpty(gatunekSzukany)
                    || z.Gatunek.Contains(gatunekSzukany, StringComparison.OrdinalIgnoreCase)
                select z;

            return wynik.ToList();
        }

        #endregion

        #region Obsługa JSON
        public void ZapiszDoPlikow(string sciezka = "klinika.json")
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // Ignoruj null
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Polskie znaki
                };

                string json = JsonSerializer.Serialize(this, options);
                File.WriteAllText(sciezka, json);

                Console.WriteLine($"Dane zapisane do pliku: {sciezka}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd zapisu: {ex.Message}");
                throw;
            }
        }

        public static Klinika? WczytajZPlikow(string sciezka = "klinika.json")
        {
            try
            {
                if (!File.Exists(sciezka))
                {
                    Console.WriteLine($"Plik {sciezka} nie istnieje!");
                    return null;
                }

                string json = File.ReadAllText(sciezka);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                var klinika = JsonSerializer.Deserialize<Klinika>(json, options);

                if (klinika != null)
                {
                    // PRZYWRÓĆ REFERENCJE do kliniki w obiektach
                    PrzywrocReferencje(klinika);
                    Console.WriteLine($"Dane wczytane z pliku: {sciezka}");
                }

                return klinika;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Błąd parsowania JSON: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd odczytu: {ex.Message}");
                return null;
            }
        }

        // Metoda pomocnicza do przywrócenia referencji
        private static void PrzywrocReferencje(Klinika klinika)
        {
            // Przywróć referencje w zwierzętach
            foreach (var zwierze in klinika.Zwierzeta)
            {
                zwierze.Klinika = klinika;
            }

            // Przywróć referencje w właścicielach
            foreach (var wlasciciel in klinika.Wlasciciele)
            {
                wlasciciel.Klinika = klinika;
            }

            // Przywróć referencje w lekarzach
            foreach (var lekarz in klinika.Lekarze)
            {
                lekarz.Klinika = klinika;
            }
        }

        #endregion


        #region Events
        public event EventHandler<KonfliktLekowEventArgs>? KonfliktLekow;

        // Metoda do wywoływania eventu
        internal virtual void OnKonfliktLekow(KonfliktLekowEventArgs e)
        {
            KonfliktLekow?.Invoke(this, e);
        }

        #endregion
    }
}