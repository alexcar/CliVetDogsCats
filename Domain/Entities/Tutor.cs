namespace Domain.Entities
{
    public class Tutor : BaseEntity
    {
        public Tutor(string? name, string? cpf, string? rg, string? phone, string? cellPhone, string? dayMonthBirth, string? comments)
        {
            Name = name;
            Cpf = cpf;
            Rg = rg;
            Phone = phone;
            CellPhone = cellPhone;
            DayMonthBirth = dayMonthBirth;
            Comments = comments;
        }

        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Rg { get; set; }
        public string? Phone { get; set; }
        public string? CellPhone { get; set; }
        public string? DayMonthBirth { get; set; }
        public string? Comments { get; set; }
    }
}
