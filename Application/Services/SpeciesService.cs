using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly CliVetDogsCatsContext _context;

        public SpeciesService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<SpeciesResponse>> GetAllAsync()
        {
            return await _context.Species
                .Where(x => x.Active == true)
                .Select(x => new SpeciesResponse(x.Id, x.Name))
                .ToListAsync();
        }
    }
}
