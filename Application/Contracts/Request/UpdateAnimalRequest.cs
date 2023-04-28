namespace Application.Contracts.Request
{
    public class UpdateAnimalRequest : AnimalRequest
    {
        public Guid Id { get; set; }
    }
}
