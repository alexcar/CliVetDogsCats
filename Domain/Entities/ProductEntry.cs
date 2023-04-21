namespace Domain.Entities
{
    public class ProductEntry : BaseEntity
    {
        public ProductEntry()
        {
            
        }
        public ProductEntry(Guid productId, decimal costValue, int quantity)
        {
            ProductId = productId;
            CostValue = costValue;
            Quantity = quantity;
        }

        public decimal CostValue { get; private set; }
        public int Quantity { get; private set; }

        public Guid ProductEntryHeaderId { get; set; }
        public ProductEntryHeader ProductEntryHeader { get; set; } = new ProductEntryHeader();
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = new Product();
    }
}
