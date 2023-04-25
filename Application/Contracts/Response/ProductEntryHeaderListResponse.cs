namespace Application.Contracts.Response
{
    public record ProductEntryHeaderListResponse(
        Guid Id, 
        string Code, 
        string EmployeeName, 
        string SupplierName, 
        DateTime? Date, 
        string TransactionType,
        decimal TotalValue);
}
