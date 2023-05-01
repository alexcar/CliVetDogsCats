namespace Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule()
        {
            
        }
        public Schedule(DateTime scheduleDate, byte hour, string tutorComments, string scheduleComments)
        {
            ScheduleDate = scheduleDate;
            Hour = hour;
            TutorComments = tutorComments;
            ScheduleComments = scheduleComments;
        }

        public DateTime ScheduleDate { get; set; }
        public byte Hour { get; set; }
        public string TutorComments { get; set; }
        public string ScheduleComments { get; set; }
        public Guid ScheduleStatusId { get; set; }
        public ScheduleStatus ScheduleStatus { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid TutorId { get; set; }
        public Tutor Tutor { get; set; }
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
        
        public List<Product> Products { get; } = new();
        public List<Service> Services { get; } = new();
    }
}
