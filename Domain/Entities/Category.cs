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

        IEnumerable<Product> Products { get; set; }
    }
}
