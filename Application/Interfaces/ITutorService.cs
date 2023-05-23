using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface ITutorService
    {
        public Task<List<TutorListResponse>> GetAllAsync();
        public Task<TutorResponse?> GetByIdAsync(Guid id);
        public Task<List<TutorListResponse>> GetAllTutorsHaveAnimalAsync();
        public Task<List<TutorReportResponse>> ReportAsync();
        public Task<TutorResponse> CreateAsync(CreateTutorRequest request);
        public Task<TutorResponse> UpdateAsync(UpdateTutorRequest request);
        public Task DeleteAsync(Guid id);
    }
}
