namespace Domain.Entities
{
    public class Sexy : BaseEntity
    {
        public Sexy(string? name)
        {
            Name = name;
        }

        public string? Name { get; set; }
    }
}
