namespace Domain.Entities
{
    public class Race : BaseEntity
    {
        public Race()
        {
            
        }
        public Race(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Guid SpeciesId { get; set; }
        public Species Species { get; set; } = new Species();
    }
}
