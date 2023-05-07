using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleListResponse>?> GetAllAsync();
        Task<ScheduleResponse?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateScheduleRequest request);
        Task UpdateAsync(UpdateScheduleRequest request);
        Task ScheduleStart(ScheduleStartRequest request);
        Task ScheduleEnd(ScheduleEndRequest request);
        Task ScheduleCancellation(ScheduleCancellationRequest request);
    }
}
