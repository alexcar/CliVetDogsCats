namespace Domain.Entities
{
    public class Size : BaseEntity
    {
        public Size(string? name)
        {
            Name = name;
        }

        public string? Name { get; set; }
    }
}
