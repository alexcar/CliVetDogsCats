using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IAnimalSizeService
    {
        Task<List<AnimalSizeResponse>> GetAllAsync();
    }
}
