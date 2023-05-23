namespace Domain.Entities
{
    public class Tutor : BaseEntity
    {
        public Tutor()
        {
            
        }

        public Tutor(
            string name, 
            string cpf, 
            string rg, 
            string? phone, 
            string cellPhone, 
            string email,
            string? dayMonthBirth, 
            string? comments)
        {
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
            DayMonthBirth = dayMonthBirth;
            Comments = comments;
        }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string? Phone { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }
        public string? DayMonthBirth { get; private set; }
        public string? Comments { get; private set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = new Address();
        public IEnumerable<Animal> Animals { get; set; }

        public void AddAddress(Address address)
        {
            Address = address;
        }

        public void UpdateAddress(Address address) 
        {
            Address = address;
        }

        public void Update(
            Guid id,
            string name,
            string cpf,
            string rg,
            string phone,
            string cellPhone,
            string email,
            string dayMonthBirth,
            string comments,
            bool active)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
            DayMonthBirth = dayMonthBirth;
            Comments = comments;            
            Active = active;
        }
    }
}
