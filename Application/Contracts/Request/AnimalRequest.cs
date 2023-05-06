namespace Application.Contracts.Request
{
    public class AnimalRequest
    {
        public string Name { get; set; }
        public string Coat { get; set; }
        public string SexoId { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Weigth { get; set; }
        public string? Comments { get; set; }
        public Guid TutorId { get; set; }
        public Guid SpeciesId { get; set; }
        public Guid RaceId { get; set; }
        public Guid AnimalSizeId { get; set; }
    }
}
