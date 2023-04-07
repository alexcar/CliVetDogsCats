namespace Application.Contracts.Response
{
    public class SupplierResponse
    {
        public SupplierResponse(
            Guid id, string name, string trade, string contact, 
            string email, string cnpj, string phone, string cellPhone, bool? active, AddressResponse address)
        {
            Id = id;
            Name = name;
            Trade = trade;
            Contact = contact;
            Email = email;
            Cnpj = cnpj;
            Phone = phone;
            CellPhone = cellPhone;
            Active = active;
            Address = address;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Trade { get; }
        public string Contact { get; }
        public string Email { get; }
        public string Cnpj { get; }
        public string Phone { get; }
        public string CellPhone { get; }
        public bool? Active { get; }
        public AddressResponse Address { get; }
    }
}
