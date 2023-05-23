namespace Application.Contracts.Response
{
    public record EmployeeReportResponse(
        string Name,
        string Cpf,
        string CellPhone,
        string Email,
        DateTime AdmissionDate,
        bool IsVeterinarian);
}
