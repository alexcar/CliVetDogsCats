namespace Application.Contracts.Request
{
    public class ProductRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostValue { get; set; }
        public int ProfitMargin { get; set; }
        public decimal SaleValue { get; set; }
        public int StockQuantity { get; set; }
        public CategoryRequest Category { get; set; }
        public BrandRequest Brand { get; set; }
        public bool Active { get; set; }
    }
}
