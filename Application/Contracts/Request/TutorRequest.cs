namespace Application.Contracts.Request
{
    public class TutorRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string DayBirth { get; set; }
        public string MonthBirth { get; set; }
        public string DayMonthBirth { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }        
    }
}
