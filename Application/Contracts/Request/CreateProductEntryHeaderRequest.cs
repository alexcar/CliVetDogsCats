namespace Application.Contracts.Request
{
    public class CreateProductEntryHeaderRequest
    {
        public string Code { get; set; }
        public string TransactionType { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid SupplierId { get; set; }        
        public IEnumerable<CreateProductEntryRequest> ProductsEntry { get; set; }
    }
}
