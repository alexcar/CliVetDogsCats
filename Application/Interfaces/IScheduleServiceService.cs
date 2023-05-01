using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IScheduleServiceService
    {
        public Task<List<ScheduleServiceResponse>> GetAll();
    }
}
