using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IAnimalService
    {
        Task<List<AnimalListResponse>> GetAllAsync();
        Task<AnimalResponse?> GetByIdAsync(Guid id);
        Task<AnimalResponse> CreateAsync(CreateAnimalRequest request);
        Task<AnimalResponse> UpdateAsync(UpdateAnimalRequest request);
        Task DeleteAsync(Guid id);
    }
}
