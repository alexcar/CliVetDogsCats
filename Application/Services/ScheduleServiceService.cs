using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ScheduleServiceService : IScheduleServiceService
    {
        private readonly CliVetDogsCatsContext _context;

        public ScheduleServiceService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleServiceResponse>> GetAll()
        {
            return await _context.Services
                .Where(x => x.Active == true)
                .Select(p => new ScheduleServiceResponse(p.Id, p.Name, p.SaleValue))
                .AsNoTracking().ToListAsync();
        }
    }
}
