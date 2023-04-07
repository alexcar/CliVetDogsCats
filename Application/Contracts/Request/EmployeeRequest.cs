namespace Application.Contracts.Request
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Gender { get; set; }        
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }        
        public bool IsVeterinarian { get; set; }
        public bool Active { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
