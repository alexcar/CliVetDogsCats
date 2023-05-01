using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IScheduleStatusService
    {
        public Task<List<ScheduleStatusResponse>> GetAll();
    }
}
