namespace Application.Contracts.Response
{
    public record SelectedScheduleProductResponse(Guid ProductId, string ProductName, decimal SaleValue, int Quantity);
}
