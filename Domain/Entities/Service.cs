namespace Domain.Entities
{
    public class Service : BaseEntity
    {
        public Service(string? name, decimal? value)
        {
            Name = name;
            Value = value;
        }

        public string? Name { get; set; }
        public decimal? Value { get; set; }
    }
}
