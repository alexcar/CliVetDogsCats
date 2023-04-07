namespace Application.Contracts.Request
{
    public class AddressRequest
    {
        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
