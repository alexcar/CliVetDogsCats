namespace Application.Contracts.Request
{
    public class UpdateScheduleRequest : ScheduleRequest
    {
        public Guid Id { get; set; }
    }
}
