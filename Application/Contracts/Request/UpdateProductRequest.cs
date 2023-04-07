namespace Application.Contracts.Request
{
    public class UpdateProductRequest : ProductRequest 
    {
        public Guid Id { get; set; }
    }
}
