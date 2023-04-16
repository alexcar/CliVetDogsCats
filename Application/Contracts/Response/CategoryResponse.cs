namespace Application.Contracts.Response
{
    public class CategoryResponse
    {
        public CategoryResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }        
    }
}
