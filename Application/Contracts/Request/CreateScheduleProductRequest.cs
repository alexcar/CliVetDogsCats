namespace Application.Contracts.Request
{
    public class CreateScheduleProductRequest
    {
        public Guid ProductId { get; set; }        
        public int Quantity { get; set; }
    }
}
