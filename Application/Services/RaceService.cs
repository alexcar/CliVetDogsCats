using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class RaceService : IRaceService
    {
        private readonly CliVetDogsCatsContext _context;

        public RaceService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<RaceResponse>> GetAllAsync()
        {
            return await _context.Races
                .Where(x => x.Active == true)
                .Select(x => new RaceResponse(x.Id, x.Name))
                .ToListAsync();
        }
    }
}
