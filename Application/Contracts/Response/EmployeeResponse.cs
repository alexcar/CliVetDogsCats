namespace Application.Contracts.Response
{
    public class EmployeeResponse
    {
        public EmployeeResponse(
            Guid id, string name, string cpf, string rg, string gender, string phone, 
            string cellPhone, string email, bool isVeterinarian, DateTime admissionDate, 
            bool? active, AddressResponse address, WorkShiftResponse? workShift)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Gender = gender;
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
            IsVeterinarian = isVeterinarian;
            Active = active;
            AdmissionDate = admissionDate;
            Address = address;
            WorkShift = workShift;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Cpf { get; }
        public string Rg { get; }
        public string Gender { get; }
        public string Phone { get; }
        public string CellPhone { get; }
        public string Email { get; }
        public bool IsVeterinarian { get; }
        public DateTime AdmissionDate { get; }
        public bool? Active { get; set; }

        public AddressResponse Address { get; }
        public WorkShiftResponse? WorkShift { get; set; }
    }
}
