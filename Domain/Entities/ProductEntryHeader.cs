namespace Domain.Entities
{
    public class ProductEntryHeader : BaseEntity
    {
        public ProductEntryHeader()
        {
            
        }

        public ProductEntryHeader(string? code)
        {
            Code = code;
        }

        public string? Code { get; private set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; } = new Supplier();
        public IEnumerable<ProductEntry> ProductsEntry { get; set; } = new List<ProductEntry>();
    }
}
