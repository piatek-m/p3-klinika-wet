namespace KlinikaWeterynaryjna
{
    // Klasa Wizyta
    public class Wizyta
    {
        public Wizyta(int _id, DateTime _data, int _idZwierz, int _idLekarza, string? _diagnoza, string? _zalecenia)
        =>
        (Id, Data, IdZwierzecia, IdLekarza, Diagnoza, Zalecenia) = (_id, _data, _idZwierz, _idLekarza, _diagnoza, _zalecenia);

        public int Id { get; init; } // Id wizyty
        public DateTime Data { get; init; } // Data wizyty
        public int IdZwierzecia { get; init; } // Id zwierzecia, czyli pacjenta
        public int IdLekarza { get; init; } // Id lekarza prowadzącego wizytę
        public string? Diagnoza { get; init; } // Diagnoza postawiona na wizycie 
        public string? Zalecenia { get; init; } // Zalecenia wystawione na wizycie

    }
}