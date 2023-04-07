namespace Domain.Entities
{
    public class Animal : BaseEntity
    {
        public Animal(string? name, string? coat, DateTime? birthDate, decimal? weigth, string? comments)
        {
            Name = name;
            Coat = coat;
            BirthDate = birthDate;
            Weigth = weigth;
            Comments = comments;
        }

        public string? Name { get; set; }
        public string? Coat { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Weigth { get; set; }
        public string? Comments { get; set; }
    }
}
