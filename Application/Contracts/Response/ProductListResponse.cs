namespace Application.Contracts.Response
{
    public record ProductListResponse(
        Guid Id, string Name, string BrandName, 
        string CategoryName, decimal CostValue, decimal SaleValue);
    
}
