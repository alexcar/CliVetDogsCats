using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly CliVetDogsCatsContext _context;
        private const string entityName = "animal";

        public AnimalService(CliVetDogsCatsContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalListResponse>> GetAllAsync()
        {
            return await _context.Animals
                .Include(x => x.Tutor)
                .Include(x => x.Species)
                .Include(x => x.Race)
                .Where(x => x.Active == true)
                .Select(p => new AnimalListResponse(p.Id, p.Name, p.Tutor.Name, p.Species.Name, p.Race.Name, p.Coat))
                .AsNoTracking()
                .ToListAsync();                
        }

        public async Task<AnimalResponse?> GetByIdAsync(Guid id)
        {
            return await _context.Animals
                .Where(x => x.Active == true && x.Id == id)
                .Select(p => new AnimalResponse(
                    p.Id, p.Name, p.Coat, p.Sexo, p.BirthDate, 
                    p.Weigth, p.Comments, p.TutorId, p.SpeciesId, 
                    p.RaceId, p.AnimalSizeId, p.Active))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<List<AnimalListResponse>> GetByTutorIdAsync(Guid id)
        {
            return await _context.Animals
                .Include(x => x.Tutor)
                .Include(x => x.Species)
                .Include(x => x.Race)
                .OrderBy(x => x.Name)
                .Where(x => x.Active == true && x.TutorId == id)
                .Select(p => new AnimalListResponse(p.Id, p.Name, p.Tutor.Name, p.Species.Name, p.Race.Name, p.Coat))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<AnimalReportResponse>> ReportAsync()
        {
            return await _context.Animals
                .Include(x => x.Tutor)
                .Include(x => x.Species)
                .Include(x => x.Race)
                .Where(x => x.Active == true)
                .Select(p => new AnimalReportResponse(p.Name, p.Tutor.Name, p.Sexo, p.BirthDate, p.Species.Name, p.Race.Name, p.Coat))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AnimalResponse> CreateAsync(CreateAnimalRequest request)
        {
            var animal = new Animal(request.Name, request.Coat, request.SexoId, request.BirthDate, request.Weigth,
                request.Comments, request.TutorId, request.SpeciesId, request.RaceId, request.AnimalSizeId);

            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();

            return new AnimalResponse(animal.Id, animal.Name, animal.Coat, animal.Sexo, animal.BirthDate, animal.Weigth,
                animal.Comments, animal.TutorId, animal.SpeciesId, animal.RaceId, animal.AnimalSizeId, animal.Active);
        }

        public async Task<AnimalResponse> UpdateAsync(UpdateAnimalRequest request)
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == request.Id);

            if (animal == null)
                throw new EmployeeNotFoundException(entityName, request.Id);

            animal.Name = request.Name;
            animal.Coat = request.Coat;
            animal.Sexo = request.SexoId;
            animal.BirthDate = request.BirthDate;
            animal.Weigth = request.Weigth;
            animal.Comments = request.Comments;
            animal.TutorId = request.TutorId;
            animal.SpeciesId = request.SpeciesId;
            animal.RaceId = request.RaceId;
            animal.AnimalSizeId = request.AnimalSizeId;

            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();

            return new AnimalResponse(animal.Id, animal.Name, animal.Coat, animal.Sexo, animal.BirthDate, animal.Weigth,
                animal.Comments, animal.TutorId, animal.SpeciesId, animal.RaceId, animal.AnimalSizeId, animal.Active);
        }

        public async Task DeleteAsync(Guid id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);

            if (animal == null)
                throw new EmployeeNotFoundException(entityName, id);

            animal.Active = false;

            _context.Animals.Update(animal);
            await _context.SaveChangesAsync();
        }
    }
}
