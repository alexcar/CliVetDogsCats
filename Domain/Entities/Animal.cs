namespace Domain.Entities
{
    public class Animal : BaseEntity
    {
        public Animal()
        {
            
        }
        public Animal(
            string name, string coat, string sexo, DateTime birthDate, 
            decimal weigth, string? comments, Guid tutorId, Guid speciesId, Guid raceId, Guid animalSizeId)
        {
            Name = name;
            Coat = coat;
            Sexo = sexo;
            BirthDate = birthDate;
            Weigth = weigth;
            Comments = comments;
            TutorId = tutorId;
            SpeciesId = speciesId;
            RaceId = raceId;
            AnimalSizeId = animalSizeId;
        }

        public string Name { get; set; }
        public string Coat { get; set; }
        public string Sexo { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Weigth { get; set; }
        public string? Comments { get; set; }
        public Guid TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public Guid SpeciesId { get; set; }
        public Species Species { get; set; }
        public Guid RaceId { get; set; }
        public Race Race { get; set; }
        public Guid AnimalSizeId { get; set; }
        public AnimalSize Size { get; set; }        
    }
}
