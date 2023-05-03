namespace Application.Contracts.Request
{
    public class ScheduleStartRequest
    {
        public Guid ScheduleId { get; set; }
        public Guid ScheduleStatusId { get; set; }
    }
}
