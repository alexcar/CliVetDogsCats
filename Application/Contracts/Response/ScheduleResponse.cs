namespace Application.Contracts.Response
{
    public class ScheduleResponse
    {
        public ScheduleResponse(
            Guid scheduleId, DateTime scheduleDate, byte hour, 
            string tutorComments, string scheduleComments, Guid scheduleStatusId, 
            List<ScheduleStatusResponse> scheduleStatus, Guid tutorId, 
            List<TutorListResponse> tutors, Guid animalId, 
            List<AnimalListResponse> animals, Guid employeeId, 
            List<ScheduleServiceResponse> scheduleServices, 
            List<ScheduleProductResponse> scheduleProducts, 
            List<SelectedScheduleServiceResponse> selectedScheduleService, 
            List<SelectedScheduleProductResponse> selectedScheduleProduct)
        {
            ScheduleId = scheduleId;
            ScheduleDate = scheduleDate;
            Hour = hour;
            TutorComments = tutorComments;
            ScheduleComments = scheduleComments;
            ScheduleStatusId = scheduleStatusId;
            ScheduleStatus = scheduleStatus;
            TutorId = tutorId;
            Tutors = tutors;
            AnimalId = animalId;
            Animals = animals;
            EmployeeId = employeeId;
            ScheduleServices = scheduleServices;
            ScheduleProducts = scheduleProducts;
            ScheduleServiceSelected = selectedScheduleService;
            ScheduleProductSelected = selectedScheduleProduct;
        }

        public Guid ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public byte Hour { get; set; }
        public string TutorComments { get; set; }
        public string ScheduleComments { get; set; }
        public Guid ScheduleStatusId { get; set; }
        public List<ScheduleStatusResponse> ScheduleStatus { get; set; } = new List<ScheduleStatusResponse>();
        public Guid TutorId { get; set; }
        public List<TutorListResponse> Tutors { get; set; }
        public Guid AnimalId { get; set; }
        public List<AnimalListResponse> Animals { get; set; }
        public Guid EmployeeId { get; set; }        
        public List<ScheduleServiceResponse> ScheduleServices { get; set; }
        public List<ScheduleProductResponse> ScheduleProducts { get; set; }
        public List<SelectedScheduleServiceResponse> ScheduleServiceSelected { get; set; }
        public List<SelectedScheduleProductResponse> ScheduleProductSelected { get; set; }
    }
}
