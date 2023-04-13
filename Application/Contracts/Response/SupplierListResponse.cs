namespace Application.Contracts.Response
{
    public record SupplierListResponse(Guid Id, string Trade, string Cnpj, string Contact, string CellPhone);
    
}
