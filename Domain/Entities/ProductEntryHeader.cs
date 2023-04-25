namespace Domain.Entities
{
    public class ProductEntryHeader : BaseEntity
    {
        public ProductEntryHeader()
        {
            
        }

        public ProductEntryHeader(string code, string transactionType, Guid employeeId, Guid supplierId, IEnumerable<ProductEntry> productsEntry)
        {
            Code = code;
            TransactionType = transactionType;
            EmployeeId = employeeId;
            SupplierId = supplierId;
            ProductsEntry = productsEntry;
        }

        public string Code { get; private set; }
        public Guid EmployeeId { get; set; }
        public string TransactionType { get; private set; }
        public Employee Employee { get; set; } = new Employee();
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();
        public IEnumerable<ProductEntry> ProductsEntry { get; set; } = new List<ProductEntry>();
    }
}
