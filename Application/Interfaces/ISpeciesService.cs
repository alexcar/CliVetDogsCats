using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface ISpeciesService
    {
        Task<List<SpeciesResponse>> GetAllAsync();
    }
}
