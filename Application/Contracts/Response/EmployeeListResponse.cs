namespace Application.Contracts.Response
{
    public record EmployeeListResponse(
        Guid Id, 
        string Name, 
        string Cpf, 
        string CellPhone, 
        bool IsVeterinarian);
    
}
