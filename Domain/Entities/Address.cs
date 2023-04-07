namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public Address()
        {
            
        }

        public Address(string zipCode, string streetAddress, string number, string? complement, string neighborhood, string city, string state, string country)
        {
            ZipCode = zipCode;
            StreetAddress = streetAddress;
            Number = number;
            Complement = complement;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
        }

        public string ZipCode { get; set; }
        public string StreetAddress { get; set; }
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }        

        public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
    }
}
