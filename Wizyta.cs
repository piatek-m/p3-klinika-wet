namespace KlinikaWeterynaryjna
{
    // Klasa Wizyta
    public class Wizyta
    {
        // Pola required - nie wymagają konstruktora jawnego
        // Oddelegowanie pracy do object initializera
        public required int Id { get; init; } // Id wizyty
        public required DateTime Data { get; init; } // Data wizyty
        public required int IdZwierzecia { get; init; } // Id zwierzecia, czyli pacjenta
        public required int IdLekarza { get; init; } // Id lekarza prowadzącego wizytę
        public string? Diagnoza { get; set; } // Diagnoza postawiona na wizycie 
        public string? Zalecenia { get; set; } // Zalecenia wystawione na wizycie

    }
}