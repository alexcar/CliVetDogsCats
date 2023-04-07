namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(
            string code, string name, string description, decimal costValue, 
            int profitMargin, decimal saleValue, int stockQuantity)
        {
            Code = code;
            Name = name;
            Description = description;
            CostValue = costValue;
            ProfitMargin = profitMargin;
            SaleValue = saleValue;
            StockQuantity = stockQuantity;
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostValue { get; set; }
        public int ProfitMargin { get; set; }
        public decimal SaleValue { get; set; }
        public int StockQuantity { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = new Brand();
    }
}
