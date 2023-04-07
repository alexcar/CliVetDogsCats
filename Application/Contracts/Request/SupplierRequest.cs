namespace Application.Contracts.Request
{
    public class SupplierRequest
    {
        public string Name { get; set; }
        public string Trade { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }        
        public bool Active { get; set; }
    }
}
