namespace Domain.Entities
{
    public class AnimalSize : BaseEntity
    {
        public AnimalSize()
        {
            
        }
        public AnimalSize(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
