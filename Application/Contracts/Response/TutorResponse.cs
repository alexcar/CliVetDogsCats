using Domain.Entities;

namespace Application.Contracts.Response
{
    public class TutorResponse
    {
        public TutorResponse(
            Guid id,
            string name,
            string cpf,
            string rg,
            string phone,
            string cellPhone,
            string email,
            string dayMonthBirth,
            string comments,
            AddressResponse address)
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
            Address = address;
        }

        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }
        public string Email { get; private set; }
        public string DayMonthBirth { get; private set; }
        public string Comments { get; private set; }
        public AddressResponse Address { get; set; } = new AddressResponse();
    }
}
