namespace Application.Contracts.Response
{
    public record ScheduleListResponse(
        Guid Id, string TutorName, string VetName, string AnimalName, 
        DateTime ScheduleDate, byte Hour, string Status);
}
