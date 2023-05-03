namespace Application.Contracts.Request
{
    public class ScheduleEndRequest
    {
        public Guid ScheduleId { get; set; }
        public Guid ScheduleStatusId { get; set; }   
    }
}
