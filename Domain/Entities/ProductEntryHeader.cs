namespace Domain.Entities
{
    public class ProductEntryHeader : BaseEntity
    {
        public ProductEntryHeader(string? code)
        {
            Code = code;
        }

        public string? Code { get; set; }

    }
}
