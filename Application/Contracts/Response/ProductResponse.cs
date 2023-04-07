namespace Application.Contracts.Response
{
    public class ProductResponse
    {
        public ProductResponse(
            Guid id, string code, string name, string description, 
            decimal costValue, int profitMargin, decimal saleValue, 
            int stockQuantity, Guid categoryId, Guid brandId, bool? active)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            CostValue = costValue;
            ProfitMargin = profitMargin;
            SaleValue = saleValue;
            StockQuantity = stockQuantity;
            CategoryId = categoryId;
            BrandId = brandId;
            Active = active;
        }

        public Guid Id { get; }
        public string Code { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal CostValue { get; }
        public int ProfitMargin { get; }
        public decimal SaleValue { get; }
        public int StockQuantity { get; }
        public Guid CategoryId { get; }
        public Guid BrandId { get; }
        public bool? Active { get; }
    }
}
