namespace Domain.Entities
{
    public class ProductEntry : BaseEntity
    {
        public ProductEntry(decimal? costValue, int? quantity)
        {
            CostValue = costValue;
            Quantity = quantity;
        }

        public decimal? CostValue { get; set; }
        public int? Quantity { get; set; }
    }
}
