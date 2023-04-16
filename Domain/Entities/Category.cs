namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            
        }

        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Brand> Brands { get; set;} = new List<Brand>();
    }
}
