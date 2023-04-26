namespace Application.Contracts.Response
{
    public class ProductEntryResponse
    {
        public ProductEntryResponse(
            Guid id, 
            Guid productEntryHeaderId, 
            Guid productId, 
            string code, 
            string name, 
            decimal costValue, 
            int quantity,
            decimal subTotal)
        {
            Id = id;
            ProductEntryHeaderId = productEntryHeaderId;
            ProductId = productId;
            Code = code;
            Name = name;
            CostValue = costValue;
            Quantity = quantity;
            SubTotal = subTotal;
        }

        public Guid Id { get; private set; }
        public Guid ProductEntryHeaderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal CostValue { get; private set; }
        public int Quantity { get; private set; }
        public decimal SubTotal { get; private set; }

    }
}
