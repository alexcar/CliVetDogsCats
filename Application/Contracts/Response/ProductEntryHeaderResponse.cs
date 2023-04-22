namespace Application.Contracts.Response
{
    public class ProductEntryHeaderResponse
    {
        public ProductEntryHeaderResponse(
            Guid id, 
            string code, 
            Guid employeeId, 
            Guid supplierId, 
            List<ProductEntryResponse> productEntries) 
        { 
            Id = id;
            Code = code;
            EmployeeId = employeeId;
            SupplierId = supplierId;
            ProductEntries = productEntries;
        }

        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public Guid EmployeeId { get; private set; }
        public Guid SupplierId { get; private set; }
        public List<ProductEntryResponse> ProductEntries { get; private set; } = new List<ProductEntryResponse>();
    }
}
