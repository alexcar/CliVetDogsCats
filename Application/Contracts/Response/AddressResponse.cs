namespace Application.Contracts.Response
{
    public class AddressResponse
    {
        public AddressResponse(Guid id, string? zipCode, string? streetAddress, string? number, string? complement, string? neighborhood, string? city, string? state, string? country)
        {
            Id = id;
            ZipCode = zipCode;
            StreetAddress = streetAddress;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
        }

        public Guid Id { get; }
        public string? ZipCode { get; }
        public string? StreetAddress { get; }
        public string? Number { get; }
        public string? Complement { get; }
        public string? Neighborhood { get; }
        public string? City { get; }
        public string? State { get; }
        public string? Country { get; }
    }
}
