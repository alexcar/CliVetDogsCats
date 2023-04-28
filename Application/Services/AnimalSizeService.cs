using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AnimalSizeService : IAnimalSizeService
    {
        private readonly CliVetDogsCatsContext _context;

        public AnimalSizeService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalSizeResponse>> GetAllAsync()
        {
            return await _context.AnimalSizes
                .Where(x => x.Active == true)
                .Select(x => new AnimalSizeResponse(x.Id, x.Name))
                .ToListAsync();
        }
    }
}
