namespace Application.Contracts.Response
{
    public record ProductListResponse(
        Guid Id, string Name, string Brand, 
        string Category, decimal CostValue, decimal SaleValue);
    
}
