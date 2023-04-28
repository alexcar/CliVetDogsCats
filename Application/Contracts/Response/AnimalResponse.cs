namespace Application.Contracts.Response
{
    public class AnimalResponse
    {
        public AnimalResponse(
            Guid id, string name, string coat, 
            string sexo, DateTime birthDate, decimal weigth, 
            string? comments, Guid tutorId, Guid speciesId, 
            Guid raceId, Guid animalSizeId)
        {
            Id = id;
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

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Coat { get; private set; }
        public string Sexo { get; private set; }
        public DateTime BirthDate { get; private set; }
        public decimal Weigth { get; private set; }
        public string? Comments { get; private set; }
        public Guid TutorId { get; private set; }
        public Guid SpeciesId { get; private set; }        
        public Guid RaceId { get; private set; }        
        public Guid AnimalSizeId { get; private set; }        
    }
}
