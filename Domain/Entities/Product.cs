namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            
        }
        public Product(
            string code, string name, string description, decimal costValue, 
            int profitMargin, decimal saleValue, int stockQuantity, Guid categoryId, Guid brandId)
        {
            Code = code;
            Name = name;
            Description = description;
            CostValue = costValue;
            ProfitMargin = profitMargin;
            SaleValue = saleValue;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
            BrandId = brandId;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostValue { get; set; }
        public int ProfitMargin { get; set; }
        public decimal SaleValue { get; set; }
        public int StockQuantity { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<ProductEntry> ProductsEntry { get; set; } = new List<ProductEntry>();
    }
}
