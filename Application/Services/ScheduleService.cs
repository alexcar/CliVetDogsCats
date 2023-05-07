using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly CliVetDogsCatsContext _context;
        private const string entityName = "agendamento";

        public ScheduleService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleListResponse>?> GetAllAsync()
        {
            return await _context.Schedules
                .Include(x => x.Tutor)
                .Include(x => x.Employee)
                .Include(x => x.Animal)
                .Include(x => x.ScheduleStatus)
                .Where(x => x.Active == true) 
                .Select(p => new ScheduleListResponse(
                    p.Id, p.Tutor.Name, p.Employee.Name, p.Animal.Name, p.ScheduleDate, p.Hour, p.ScheduleStatus.Name))
                .AsNoTracking().ToListAsync();
        }

        public async Task<ScheduleResponse?> GetByIdAsync(Guid id)
        {
            var query = await _context.Schedules
                .Include(x => x.ScheduleStatus)
                .Include(x => x.Tutor)
                .Include(x => x.Animal)
                .Include(x => x.Services)
                .Include(x => x.Products)
                .Where(x => x.Active == true && x.Id == id)
                .Select(p => new ScheduleResponse(
                    p.Id, p.ScheduleDate, p.Hour, p.TutorComments, p.ScheduleComments, p.ScheduleStatusId,
                    _context.ScheduleStatus
                        .Where(s => s.Active == true)
                        .Select(p => new ScheduleStatusResponse(p.Id, p.Name)).AsNoTracking().ToList(),
                    p.TutorId,
                    _context.Tutors
                        .Where(t => t.Active == true)
                        .Select(p => new TutorListResponse(p.Id, p.Name, p.Cpf, p.CellPhone)).AsNoTracking().ToList(),
                    p.AnimalId,
                    _context.Animals
                        .Where(a => a.Active == true)
                        .Select(p => new AnimalListResponse(p.Id, p.Name, "", "", "", "")).AsNoTracking().ToList(),
                    p.EmployeeId,
                    _context.Services
                        .Where(s => s.Active == true)
                        .Select(p => new ScheduleServiceResponse(p.Id, p.Name, p.SaleValue)).AsNoTracking().ToList(),
                    _context.Products
                        .Where(p => p.Active == true)
                        .Select(p => new ScheduleProductResponse(p.Id, p.Name, p.SaleValue)).AsNoTracking().ToList(),
                    _context.ScheduleServices
                        .Where(x => x.ScheduleId == id)
                        .Join(_context.Services,
                            ss => ss.ServiceId,
                            s => s.Id, (scheduleServices, service) => new SelectedScheduleServiceResponse(
                                service.Id, service.Name, service.SaleValue))
                        .AsNoTracking().ToList(),
                    _context.ScheduleProducts
                        .Where(x => x.ScheduleId == id)
                        .Join(_context.Products,
                            sp => sp.ProductId,
                            p => p.Id,
                            (ScheduleProducts, product) => new SelectedScheduleProductResponse(
                                product.Id, product.Name, product.SaleValue, ScheduleProducts.Quantity))
                        .AsNoTracking().ToList())).SingleOrDefaultAsync();

            return query;
        }

        public async Task CreateAsync(CreateScheduleRequest request)
        {
            var schedule = new Schedule(
                request.ScheduleDate, request.Hour, request.TutorComments, request.ScheduleComments,
                request.ScheduleStatusId, request.EmployeeId, request.TutorId, request.AnimalId);

            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateScheduleRequest request)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(x => x.Id == request.Id && x.Active == true);

            if (schedule == null)
                throw new EmployeeNotFoundException(entityName, request.Id);

            schedule.Update(
                request.ScheduleDate, 
                request.Hour, 
                request.ScheduleComments, 
                request.EmployeeId, 
                request.ScheduleStatusId);

            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task ScheduleStart(ScheduleStartRequest request)
        {
            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(x => x.Active == true && x.Id == request.ScheduleId);

            if (schedule is null)
                throw new EmployeeNotFoundException(entityName, request.ScheduleId);

            schedule.ScheduleStatusId = request.ScheduleStatusId;
            schedule.ScheduleStart = DateTime.Now;

            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task ScheduleEnd(ScheduleEndRequest request)
        {
            var schedule = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Active == true && x.Id == request.ScheduleId);

            if (schedule is null)
                throw new EmployeeNotFoundException(entityName, request.ScheduleId);

            schedule.ScheduleStatusId = request.ScheduleStatusId;
            schedule.ScheduleEnd = DateTime.Now;

            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task ScheduleCancellation(ScheduleCancellationRequest request)
        {
            var schedule = await _context.Schedules
            .FirstOrDefaultAsync(x => x.Active == true && x.Id == request.ScheduleId);

            if (schedule is null)
                throw new EmployeeNotFoundException(entityName, request.ScheduleId);

            schedule.ScheduleStatusId = request.ScheduleStatusId;
            schedule.ScheduleCancellation = DateTime.Now;
            schedule.ScheduleComments = request.ScheduleComments;

            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();
        }
    }
}
