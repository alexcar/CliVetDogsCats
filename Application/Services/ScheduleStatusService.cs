using Application.Contracts.Response;
using Application.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ScheduleStatusService : IScheduleStatusService
    {
        private readonly CliVetDogsCatsContext _context;

        public ScheduleStatusService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleStatusResponse>> GetAll()
        {
            return await _context.ScheduleStatus.Where(x => x.Active == true)
                .Select(p => new ScheduleStatusResponse(p.Id, p.Name))
                .AsNoTracking().ToListAsync();                
        }
    }
}
