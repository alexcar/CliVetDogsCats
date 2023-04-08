namespace Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            
        }
        public Supplier(
            string name, string trade, string contact, string email, string cnpj, string phone, string cellPhone)
        {
            Name = name;
            Trade = trade;
            Contact = contact;
            Email = email;
            Cnpj = cnpj;
            Phone = phone;
            CellPhone = cellPhone;
        }

        public string Name { get; set; }
        public string Trade { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }        
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = new Address();
        public IEnumerable<ProductEntryHeader> ProductsEntryHeader { get; set; } = new List<ProductEntryHeader>();

        public void AddAddress(Address address)
        {
            Address = address;
        }
    }
}
