namespace Application.Contracts.Response
{
    public record ProductEntryHeaderListResponse(
        Guid Id, 
        string Code, 
        string EmployeeName, 
        Guid SupplierId,
        string SupplierName, 
        DateTime? Date,
        string TransactionTypeId,
        string TransactionType,
        decimal TotalValue, 
        List<ProductEntryResponse>? ProductsEntry);
}
