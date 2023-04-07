namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        IEnumerable<Product> Products { get; set; }
    }
}
