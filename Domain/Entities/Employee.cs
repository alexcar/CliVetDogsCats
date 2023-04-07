namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        // TODO: Create value objects and how to update a class.

        public Employee()
        {
            
        }

        public Employee(
            string name, string cpf, string rg, string gender, string phone, string cellPhone, string email, 
            DateTime admissionDate, bool isVeterinarian)
        {
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Gender = gender;            
            Phone = phone;
            CellPhone = cellPhone;
            Email = email;
            AdmissionDate = admissionDate;
            IsVeterinarian = isVeterinarian;                        
        }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Gender { get; set; }        
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsVeterinarian { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = new Address();
        public Guid? WorkShiftId { get; set; }
        public WorkShift? WorkShift { get; set; } = new WorkShift();

        public void AddAddress(Address address)
        {
            Address = address;
        }

        public void AddWorkShift(WorkShift workShift)
        {
            WorkShift = workShift;
        }
    }
}
