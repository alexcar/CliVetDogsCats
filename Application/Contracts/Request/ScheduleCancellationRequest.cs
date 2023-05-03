namespace Application.Contracts.Request
{
    public class ScheduleCancellationRequest
    {
        public Guid ScheduleId { get; set; }
        public Guid ScheduleStatusId { get; set; }
        public string ScheduleComments { get; set; }
    }
}
