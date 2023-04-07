namespace Domain.Entities
{
    public class Specieis : BaseEntity
    {
        public Specieis(string? name)
        {
            Name = name;
        }

        public string? Name { get; set; }
    }
}
