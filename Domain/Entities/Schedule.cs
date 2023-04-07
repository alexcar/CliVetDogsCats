namespace Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public Schedule(DateTime? date, string? hour, string? tutorComments, string? scheduleComments)
        {
            Date = date;
            Hour = hour;
            TutorComments = tutorComments;
            ScheduleComments = scheduleComments;
        }

        public DateTime? Date { get; set; }
        public string? Hour { get; set; }
        public string? TutorComments { get; set; }
        public string? ScheduleComments { get; set; }
    }
}
