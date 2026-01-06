namespace KlinikaWeterynaryjna
{
    // Klasa Wizyta
    public class Wizyta
    {
        public Wizyta(int Id, DateTime Data, int IdZwierzecia, int IdLekarza) => (Id, Data, IdZwierzecia, IdLekarza) = (Id, Data, IdZwierzecia, IdLekarza);
        public required int Id { get; init; }
        public required DateTime Data { get; init; }
        public required int IdZwierzecia { get; init; }
        public required int IdLekarza { get; init; }
        public string? Diagnoza { get; set; }
        public string? Zalecenia { get; set; }
    }
}