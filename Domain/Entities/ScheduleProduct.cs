namespace Domain.Entities
{
    public class ScheduleProduct
    {
        public ScheduleProduct()
        {
            
        }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }        
        public Guid ScheduleId { get; set; }
    }
}
