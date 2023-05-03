namespace Application.Contracts.Response
{
    public record SelectedScheduleServiceResponse(Guid ServiceId, string ServiceName, decimal SaleValue);
}
