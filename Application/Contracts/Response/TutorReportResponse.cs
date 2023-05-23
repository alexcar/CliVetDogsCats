namespace Application.Contracts.Response
{
    public record TutorReportResponse(string Name, string Cpf, string Email, string CellPhone, List<AnimalReportResponse> Animals);
}
