namespace Application.Contracts.Request
{
    public class ScheduleRequest
    {
        public DateTime ScheduleDate { get; set; }
        public byte Hour { get; set; }
        public string TutorComments { get; set; }
        public string ScheduleComments { get; set; }
        public Guid ScheduleStatusId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid TutorId { get; set; }
        public Guid AnimalId { get; set; }
    }
}
