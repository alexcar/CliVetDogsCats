using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using Domain.Entities;
using Application.Exceptions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly CliVetDogsCatsContext _context;
        private readonly ILogger<EmployeeService> _logger;
        private const string entityName = "empregado";

        public EmployeeService(CliVetDogsCatsContext context, ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<EmployeeListResponse>?> GetAllAsync()
        {            
            var response = await _context.Employees
                .Where(x => x.Active == true)
                .OrderBy(x => x.Name)
                .Select(p => new EmployeeListResponse(
                    p.Id, p.Name, p.Cpf, p.CellPhone, p.IsVeterinarian))                
                .AsNoTracking().ToListAsync();                   
            
            return response;
        }

        public async Task<EmployeeResponse?> GetByIdAsync(Guid id)
        {
            var employee = await _context.Employees.Include("Address").Include("WorkShift")
                .Where(x => x.Id == id && x.Active == true).AsNoTracking().FirstOrDefaultAsync();                       

            if (employee is null)
                throw new EmployeeNotFoundException(entityName, id);

            var response = new EmployeeResponse(
                employee.Id, employee.Name, employee.Cpf, employee.Rg, employee.Gender,
                employee.Phone, employee.CellPhone, employee.Email, employee.IsVeterinarian, 
                employee.AdmissionDate, employee.Active,
                new AddressResponse(
                    employee.Address.Id, employee.Address.ZipCode, employee.Address.StreetAddress,
                    employee.Address.Number, employee.Address.Complement, employee.Address.Neighborhood,
                    employee.Address.City, employee.Address.State, employee.Address.Country),
                new WorkShiftResponse(
                    employee.WorkShift!.Id,
                    employee.WorkShift.Monday, employee.WorkShift.MondayFrom, employee.WorkShift.MondayTo,
                    employee.WorkShift.Tuesday, employee.WorkShift.TuesdayFrom, employee.WorkShift.TuesdayTo,
                    employee.WorkShift.Wednesday, employee.WorkShift.WednesdayFrom, employee.WorkShift.WednesdayTo,
                    employee.WorkShift.Thursday, employee.WorkShift.ThursdayFrom, employee.WorkShift.ThursdayTo,
                    employee.WorkShift.Friday, employee.WorkShift.FridayFrom, employee.WorkShift.FridayTo,
                    employee.WorkShift.Saturday, employee.WorkShift.SaturdayFrom, employee.WorkShift.SaturdayTo,
                    employee.WorkShift.Sunday, employee.WorkShift.SundayFrom, employee.WorkShift.SundayTo
                ));            

            return response;
        }

        public async Task<List<EmployeeListResponse>?> GetByTermAsync(string term)
        {
            var response = await _context.Employees
                .Where(x => (x.Name.Contains(term) || x.Cpf == term) && x.Active == true)
                .Select(p => new EmployeeListResponse(
                    p.Id, p.Name, p.Cpf, p.CellPhone, p.IsVeterinarian)).AsNoTracking().ToListAsync();

            return response;
        }

        public async Task<List<EmployeeResponse>?> GetAllVeterinarianAsync()
        {
            return await _context.Employees
                .Where(x => x.Active == true && x.IsVeterinarian == true)
                .Select(p => new EmployeeResponse(p .Id, p.Name))
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<EmployeeResponse>?> GetVeterinariansByDutyDateAsync(DateTime dutyDate, byte hour)
        {
            var dayOfWeek = dutyDate.DayOfWeek;
            var foo = dayOfWeek.HasFlag(DayOfWeek.Monday);
            
            var query = _context.Employees
                .Include(p => p.WorkShift)
                .Where(x => x.Active == true);
            
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    query = query.Where(x => x.WorkShift!.Monday && (hour >= x.WorkShift!.MondayFrom && hour <= x.WorkShift!.MondayTo));
                    break;
                case DayOfWeek.Tuesday:
                    query = query.Where(x => x.WorkShift!.Tuesday && (hour >= x.WorkShift!.TuesdayFrom && hour <= x.WorkShift!.TuesdayTo));
                    break;
                case DayOfWeek.Wednesday:
                    query = query.Where(x => x.WorkShift!.Wednesday && (hour >= x.WorkShift!.WednesdayFrom && hour <= x.WorkShift!.WednesdayTo));
                    break;
                case DayOfWeek.Thursday:
                    query = query.Where(x => x.WorkShift!.Thursday && (hour >= x.WorkShift!.ThursdayFrom && hour <= x.WorkShift!.ThursdayTo));
                    break;
                case DayOfWeek.Friday:
                    query = query.Where(x => x.WorkShift!.Friday && (hour >= x.WorkShift!.FridayFrom && hour <= x.WorkShift!.FridayTo));
                    break;
                case DayOfWeek.Saturday:
                    query = query.Where(x => x.WorkShift!.Saturday && (hour >= x.WorkShift!.SaturdayFrom && hour <= x.WorkShift!.SaturdayTo));
                    break;
                case DayOfWeek.Sunday:
                    query = query.Where(x => x.WorkShift!.Sunday && (hour >= x.WorkShift!.SundayFrom && hour <= x.WorkShift!.SundayTo));
                    break;
            }

            var response = await query.Select(p => new EmployeeResponse(p.Id, p.Name)).AsNoTracking().ToListAsync();

            return response;
        }

        public async Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request)
        {
            if (await CpfAlreadyRegisterd(request.Cpf))
                throw new CpfAlreadyRegisteredException(entityName, request.Cpf);

            if (await EmailAlreadyRegistered(request.Email))
                throw new EmailAlreadyRegisteredException(entityName, request.Email);

            var employee = new Employee(
                request.Name, request.Cpf, request.Rg, request.Gender, request.Phone,
                request.CellPhone, request.Email, request.AdmissionDate, request.IsVeterinarian);

            employee.AddAddress(new Address(request.Address.ZipCode, request.Address.StreetAddress, 
                request.Address.Number,request.Address.Complement, request.Address.Neighborhood, 
                request.Address.City, request.Address.State, "Brasil"));

            if (request.IsVeterinarian)
                employee.AddWorkShift(await AddWorkShift(request.WorkShift));
            else
                employee.WorkShift = null;

            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();

            var response = new EmployeeResponse(
                employee.Id, employee.Name, employee.Cpf, employee.Rg, employee.Gender,
                employee.Phone, employee.CellPhone, employee.Email, employee.IsVeterinarian,
                employee.AdmissionDate, employee.Active,
                new AddressResponse(
                    employee.Address.Id, employee.Address.ZipCode, employee.Address.StreetAddress,
                    employee.Address.Number, employee.Address.Complement, employee.Address.Neighborhood,
                    employee.Address.City, employee.Address.State, employee.Address.Country), null);

            if (request.IsVeterinarian && employee.WorkShift != null)
                response.WorkShift = await AddWorkShiftResponse(employee.WorkShift);

            return response;
        }

        public async Task<EmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
        {
            // TODO: Create value objects and how to update a class.

            var employee = await _context.Employees!.Include("Address").Include("WorkShift")
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (employee is null)
                throw new EmployeeNotFoundException(entityName, request.Id);

            if (employee.Cpf.Trim() != request.Cpf.Trim())
            {
                if (await CpfAlreadyRegisterd(request.Cpf))
                    throw new CpfAlreadyRegisteredException(entityName, request.Cpf);
            }            

            if (employee.Email.Trim() != request.Email.Trim())
            {
                // Check if the new email already exists
                if (await NewEmailAlreadyExists(employee.Id, request.Email))
                    throw new EmailAlreadyRegisteredException(entityName, request.Email);
            }

            employee.Name = request.Name;
            employee.Cpf = request.Cpf;
            employee.Rg = request.Rg;
            employee.Phone = request.Phone;
            employee.CellPhone = request.CellPhone;
            employee.Email = request.Email;
            employee.Gender = request.Gender;
            employee.AdmissionDate = request.AdmissionDate;
            employee.IsVeterinarian = request.IsVeterinarian;
            employee.Active = request.Active; 

            employee.Address.ZipCode = request.Address.ZipCode;
            employee.Address.StreetAddress = request.Address.StreetAddress;
            employee.Address.Number = request.Address.Number;
            employee.Address.Complement = request.Address.Complement;
            employee.Address.Neighborhood = request.Address.Neighborhood;
            employee.Address.City = request.Address.City;
            employee.Address.State = request.Address.State;

            if (request.IsVeterinarian && request.WorkShift != null)
            {
                employee.WorkShift!.Monday = request.WorkShift.Monday;
                employee.WorkShift.MondayFrom = request.WorkShift.MondayFrom;
                employee.WorkShift.MondayTo = request.WorkShift.MondayTo;
                employee.WorkShift.Tuesday = request.WorkShift.Tuesday;
                employee.WorkShift.TuesdayFrom = request.WorkShift.TuesdayFrom;
                employee.WorkShift.TuesdayTo = request.WorkShift.TuesdayTo;
                employee.WorkShift.Wednesday = request.WorkShift.Wednesday;
                employee.WorkShift.WednesdayFrom = request.WorkShift.WednesdayFrom;
                employee.WorkShift.WednesdayTo = request.WorkShift.WednesdayTo;
                employee.WorkShift.Thursday = request.WorkShift.Thursday;
                employee.WorkShift.ThursdayFrom = request.WorkShift.ThursdayFrom;
                employee.WorkShift.ThursdayTo = request.WorkShift.ThursdayTo;
                employee.WorkShift.Friday = request.WorkShift.Friday;
                employee.WorkShift.FridayFrom = request.WorkShift.FridayFrom;
                employee.WorkShift.FridayTo = request.WorkShift.FridayTo;
                employee.WorkShift.Saturday = request.WorkShift.Saturday;
                employee.WorkShift.SaturdayFrom = request.WorkShift.SaturdayFrom;
                employee.WorkShift.SaturdayTo = request.WorkShift.SaturdayTo;
                employee.WorkShift.Sunday = request.WorkShift.Sunday;
                employee.WorkShift.SundayFrom = request.WorkShift.SundayFrom;
                employee.WorkShift.SundayTo = request.WorkShift.SundayTo;
               
                // If GUID not valid, then create WorkShift                
                
                if (request.WorkShift.Id.ToString() == "00000000-0000-0000-0000-000000000000")
                {
                    _context.WorkShifts.Add(employee.WorkShift);
                    employee.WorkShiftId = employee.WorkShift.Id;
                }                
            }            

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            var response = new EmployeeResponse(
                employee.Id, employee.Name, employee.Cpf, employee.Rg, employee.Gender,
                employee.Phone, employee.CellPhone, employee.Email, employee.IsVeterinarian,
                employee.AdmissionDate, employee.Active,
                new AddressResponse(
                    employee.Address.Id, employee.Address.ZipCode, employee.Address.StreetAddress,
                    employee.Address.Number, employee.Address.Complement, employee.Address.Neighborhood,
                    employee.Address.City, employee.Address.State, employee.Address.Country), null);

            if (request.IsVeterinarian && employee.WorkShift != null)
                response.WorkShift = await AddWorkShiftResponse(employee.WorkShift);

            return response;
        }

        public async Task DeleteAsync(Guid id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee is null)
                throw new EmployeeNotFoundException(entityName, id);

            employee.Active = false;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CpfAlreadyRegisterd(string cpf)
        {
            return await _context.Employees.Where(x => x.Cpf == cpf).AnyAsync();
        }

        private async Task<bool> EmailAlreadyRegistered(string email)
        {
            return await _context.Employees.Where(x => x.Email == email).AnyAsync();
        }

        private async Task<bool> NewEmailAlreadyExists(Guid id, string email)
        {
            return await _context.Employees.Where(x => x.Id != id && x.Email == email).AnyAsync();
        }        

        private Task<WorkShift> AddWorkShift(CreateWorkShiftRequest workShiftRequest) 
        {
            return Task.FromResult(new WorkShift(
                workShiftRequest.Monday, workShiftRequest.MondayFrom, workShiftRequest.MondayTo,
                workShiftRequest.Tuesday, workShiftRequest.TuesdayFrom, workShiftRequest.TuesdayTo,
                workShiftRequest.Wednesday, workShiftRequest.WednesdayFrom, workShiftRequest.WednesdayTo,
                workShiftRequest.Thursday, workShiftRequest.ThursdayFrom, workShiftRequest.ThursdayTo,
                workShiftRequest.Friday, workShiftRequest.FridayFrom, workShiftRequest.FridayTo,
                workShiftRequest.Saturday, workShiftRequest.SaturdayFrom, workShiftRequest.SaturdayTo,
                workShiftRequest.Sunday, workShiftRequest.SundayFrom, workShiftRequest.SundayTo));
        }

        private Task<WorkShiftResponse> AddWorkShiftResponse(WorkShift workShift)
        {
            return Task.FromResult(new WorkShiftResponse(
                workShift.Id, 
                workShift.Monday, workShift.MondayFrom, workShift.MondayTo,
                workShift.Tuesday, workShift.TuesdayFrom, workShift.TuesdayTo,
                workShift.Wednesday, workShift.WednesdayFrom, workShift.WednesdayTo,
                workShift.Thursday, workShift.ThursdayFrom, workShift.ThursdayTo,
                workShift.Friday, workShift.FridayFrom, workShift.FridayTo,
                workShift.Saturday, workShift.SaturdayFrom, workShift.SaturdayTo,
                workShift.Sunday, workShift.SundayFrom, workShift.SundayTo));
        }
    }
}
