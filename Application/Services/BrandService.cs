using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly CliVetDogsCatsContext _context;

        public BrandService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<BrandResponse>?> GetAllAsync()
        {
            return await _context.Brands
                .Where(x => x.Active == true)
                .OrderBy(x => x.Name)
                .Select(p => new BrandResponse(p.Id, p.Name))                
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<BrandResponse>?> GetByCategoryIdAsync(Guid categoryId)
        {
            return await _context.Brands
                .Where(x => x.CategoryId == categoryId && x.Active == true)
                .Select(p => new BrandResponse(p.Id, p.Name))
                .AsNoTracking().ToListAsync();
        }
    }
}
