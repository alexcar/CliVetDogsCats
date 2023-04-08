using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CliVetDogsCatsContext _context;
        private readonly ILogger<EmployeeService> _logger;

        public CategoryService(CliVetDogsCatsContext context, ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<CategoryResponse>?> GetAllAsync()
        {
            return await _context.Categories
                .Where(x => x.Active == true)
                .Select(p => new CategoryResponse(p.Id, p.Name))
                .AsNoTracking().ToListAsync();
        }
    }
}
