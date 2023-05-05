using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class TutorService : ITutorService
    {
        private readonly CliVetDogsCatsContext _context;
        private const string entityName = "tutor";

        public TutorService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<TutorListResponse>> GetAllAsync()
        {
            var response = await _context.Tutors
                .Where(x => x.Active == true)
                .OrderBy(x => x.Name)
                .Select(p => new TutorListResponse(p.Id, p.Name, p.Cpf, p.CellPhone))
                .AsNoTracking()
                .ToListAsync();

            return response;
        }

        public async Task<TutorResponse?> GetByIdAsync(Guid id)
        {
            var response = await _context.Tutors.Include(x => x.Address)
                .Where(x => x.Id == id && x.Active == true)
                .Select(p => new TutorResponse(
                    p.Id, p.Name, p.Cpf, p.Rg, p.Phone, p.CellPhone, 
                    p.Email, p.DayMonthBirth.Substring(0,2), p.DayMonthBirth.Substring(2,2), p.Comments, p.Active,
                    new AddressResponse(
                        p.Address.Id, p.Address.ZipCode, p.Address.StreetAddress, 
                        p.Address.Number, p.Address.Complement, p.Address.Neighborhood, 
                        p.Address.City, p.Address.State, p.Address.Country)))
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return response;
        }

        public async Task<TutorResponse> CreateAsync(CreateTutorRequest request)
        {
            if (await CpfAlreadyRegisterd(request.Cpf))
                throw new CpfAlreadyRegisteredException(entityName, request.Cpf);

            if (await EmailAlreadyRegistered(request.Email))
                throw new EmailAlreadyRegisteredException(entityName, request.Email);

            var tutor = new Tutor(
                request.Name, request.Cpf, request.Rg, 
                request.Phone, request.CellPhone, request.Email, 
                request.DayBirth + request.MonthBirth, request.Comments);
            
            tutor.AddAddress(new Address(request.Address.ZipCode, request.Address.StreetAddress,
                request.Address.Number, request.Address.Complement, request.Address.Neighborhood,
                request.Address.City, request.Address.State, "Brasil"));

            await _context.Tutors.AddAsync(tutor);
            await _context.SaveChangesAsync();

            var response = new TutorResponse(tutor.Id, tutor.Name, tutor.Cpf, tutor.Rg, tutor.Phone, tutor.CellPhone,
                tutor.Email, request.DayBirth, request.MonthBirth, tutor.Comments, tutor.Active,
                new AddressResponse(tutor.Address.Id, tutor.Address.ZipCode, tutor.Address.StreetAddress,
                tutor.Address.Number, tutor.Address.Complement, tutor.Address.Neighborhood,
                tutor.Address.City, tutor.Address.State, tutor.Address.Country));

            return response;
        }

        public async Task<TutorResponse> UpdateAsync(UpdateTutorRequest request)
        {
            var tutor = await _context.Tutors.Include(x => x.Address)
                .FirstAsync(t => t.Id == request.Id);

            if (tutor is null)
                throw new EmployeeNotFoundException(entityName, request.Id);

            if (tutor.Cpf.Trim() != request.Cpf.Trim())
            {
                if (await CpfAlreadyRegisterd(request.Cpf))
                    throw new CpfAlreadyRegisteredException(entityName, request.Cpf);
            }

            if (tutor.Email.Trim() != request.Email.Trim())
            {
                // Check if the new email already exists
                if (await NewEmailAlreadyExists(tutor.Id, request.Email))
                    throw new EmailAlreadyRegisteredException(entityName, request.Email);
            }            
            
            tutor.Update(
                tutor.Id,
                request.Name, request.Cpf, request.Rg, 
                request.Phone, request.CellPhone, request.Email, 
                request.DayBirth + request.MonthBirth, request.Comments, request.Active);            

            tutor.Address.ZipCode = request.Address.ZipCode;
            tutor.Address.StreetAddress = request.Address.StreetAddress;
            tutor.Address.Number = request.Address.Number;
            tutor.Address.Complement = request.Address.Complement;
            tutor.Address.Neighborhood = request.Address.Neighborhood;
            tutor.Address.City = request.Address.City;
            tutor.Address.State = request.Address.State;            

            _context.Tutors.Update(tutor);
            await _context.SaveChangesAsync();

            var response = new TutorResponse(tutor.Id, tutor.Name, tutor.Cpf, 
                tutor.Rg, tutor.Phone, tutor.CellPhone,
                tutor.Email, request.DayBirth, request.MonthBirth, tutor.Comments, tutor.Active, 
                new AddressResponse(tutor.Address.Id, tutor.Address.ZipCode, tutor.Address.StreetAddress,
                tutor.Address.Number, tutor.Address.Complement, tutor.Address.Neighborhood, 
                tutor.Address.City, tutor.Address.State, tutor.Address.Country));

            return response;
        }

        public async Task DeleteAsync(Guid id)
        {
            var tutor = await _context.Tutors.FirstOrDefaultAsync(x => x.Id == id);
            
            if (tutor is null)
                throw new EmployeeNotFoundException(entityName, id);

            tutor.Active = false;

            _context.Tutors.Update(tutor);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CpfAlreadyRegisterd(string cpf)
        {
            return await _context.Tutors.Where(x => x.Cpf == cpf).AnyAsync();
        }

        private async Task<bool> EmailAlreadyRegistered(string email)
        {
            return await _context.Tutors.Where(x => x.Email == email).AnyAsync();
        }

        private async Task<bool> NewEmailAlreadyExists(Guid id, string email)
        {
            return await _context.Tutors.Where(x => x.Id != id && x.Email == email).AnyAsync();
        }
    }
}
