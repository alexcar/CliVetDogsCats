namespace Domain.Entities
{
    public class Brand : BaseEntity
    {
        public Brand()
        {
            
        }

        public Brand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
    }
}
