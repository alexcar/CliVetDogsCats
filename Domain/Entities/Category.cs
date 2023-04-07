namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        IEnumerable<Product> Products { get; set; }
    }
}
