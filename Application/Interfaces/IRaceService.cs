using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IRaceService
    {
        Task<List<RaceResponse>> GetAllAsync();
        Task<List<RaceResponse>> GetRaceBySpeciesIdAsync(Guid id);
    }
}
