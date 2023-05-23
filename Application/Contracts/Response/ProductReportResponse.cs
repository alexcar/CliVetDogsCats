namespace Application.Contracts.Response
{
    public record ProductReportResponse(
        string Code,
        string Name, 
        string BrandName,
        string CategoryName, 
        decimal CostValue, 
        decimal SaleValue,
        int StockQuantify);
}
