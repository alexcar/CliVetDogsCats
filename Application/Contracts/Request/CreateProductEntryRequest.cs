namespace Application.Contracts.Request
{
    public class CreateProductEntryRequest
    {
        public Guid ProductId { get; set; }
        public decimal CostValue { get; set; }
        public int Quantity { get; set; }        
    }
}
