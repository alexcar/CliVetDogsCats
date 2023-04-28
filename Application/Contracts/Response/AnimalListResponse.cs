namespace Application.Contracts.Response
{
    public record AnimalListResponse(Guid id, string name, string tutorName, string species, string race, string coat);
}
