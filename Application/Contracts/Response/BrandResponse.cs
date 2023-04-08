namespace Application.Contracts.Response
{
    public class BrandResponse
    {
        public BrandResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
