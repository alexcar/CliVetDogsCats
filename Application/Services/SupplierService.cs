using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CliVetDogsCatsContext _context;
        private readonly ILogger<EmployeeService> _logger;
        private const string entityName = "empregado";

        public SupplierService(CliVetDogsCatsContext context, ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<SupplierListResponse>?> GetAllAsync()
        {
            return await _context.Suppliers
                .Where(x => x.Active == true)
                .OrderBy(x => x.Trade)
                .Select(p => new SupplierListResponse(p.Id, p.Trade, p.Cnpj, p.Contact, p.CellPhone))                
                .AsNoTracking().ToListAsync();
        }

        public async Task<SupplierResponse?> GetByIdAsync(Guid id)
        {
            var supplier = await _context.Suppliers.Include("Address")
                .Where(x => x.Id == id && x.Active == true)
                .AsNoTracking().FirstOrDefaultAsync();

            if (supplier == null)
                throw new EntityNotFoundException($"O fornecedor com o ID: {id} não existe.");

            var response = new SupplierResponse(
                supplier.Id, supplier.Name, supplier.Trade, supplier.Contact, supplier.Email, supplier.Cnpj,
                supplier.Phone, supplier.CellPhone, supplier.Active,
                new AddressResponse(supplier.Address.Id, supplier.Address.ZipCode, supplier.Address.StreetAddress,
                    supplier.Address.Number, supplier.Address.Complement, supplier.Address.Neighborhood,
                    supplier.Address.City, supplier.Address.State, supplier.Address.Country));

            return response;
        }

        public async Task<List<SupplierListResponse>?> GetByTermAsync(string term)
        {
            return await _context.Suppliers
                .Where(x => x.Name == term && x.Active == true)
                .Select(p => new SupplierListResponse(p.Id, p.Trade, p.Cnpj, p.Contact, p.CellPhone))
                .AsNoTracking().ToListAsync();
        }

        public async Task<List<SupplierReportResponse>> ReportAsync()
        {
            return await _context.Suppliers
                .Where(x => x.Active == true)
                .OrderBy(x => x.Trade)
                .Select(p => new SupplierReportResponse(p.Trade, p.Cnpj, p.Contact, p.Email, p.CellPhone))
                .AsNoTracking().ToListAsync();
        }

        public async Task<SupplierResponse> CreateAsync(CreateSupplierRequest request)
        {
            if (await CnpjAlreadyRegistered(request.Cnpj))
                throw new PropertyBadRequestException(
                    $"Já existe um formecedor cadastrado com o CNPJ: {request.Cnpj}");

            if (await EmailAlreadyRegistered(request.Email))
                throw new EmailAlreadyRegisteredException(entityName, request.Email);

            var supplier = new Supplier(
                request.Name, 
                request.Trade, 
                request.Contact, 
                request.Email, request.Cnpj, request.Phone, request.CellPhone);

            supplier.AddAddress(new Address(
                request.Address.ZipCode, request.Address.StreetAddress,
                request.Address.Number, request.Address.Complement, request.Address.Neighborhood,
                request.Address.City, request.Address.State, "Brasil"));

            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();

            var response = new SupplierResponse(supplier.Id, supplier.Name, supplier.Trade,
                supplier.Contact, supplier.Email, supplier.Cnpj, supplier.Phone, supplier.CellPhone,
                supplier.Active, new AddressResponse(supplier.Address.Id, supplier.Address.ZipCode,
                    supplier.Address.StreetAddress, supplier.Address.Number, supplier.Address.Complement,
                    supplier.Address.Neighborhood, supplier.Address.City, supplier.Address.State,
                    supplier.Address.Country));

            return response;
        }

        public async Task<SupplierResponse> UpdateAsync(UpdateSupplierRequest request)
        {
            var supplier = await _context.Suppliers.Include("Address")
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (supplier is null)
                throw new EntityNotFoundException($"O fornecedor com o ID: {request.Id} não existe.");

            if (supplier.Cnpj.Trim() != request.Cnpj.Trim())
            {
                if (await CnpjAlreadyRegistered(request.Cnpj))
                    throw new PropertyBadRequestException(
                        $"Já existe um formecedor cadastrado com o CNPJ: {request.Cnpj}");
            }

            supplier.Name = request.Name;
            supplier.Trade = request.Trade;
            supplier.Contact = request.Contact;
            supplier.Email = request.Email;
            supplier.Cnpj  = request.Cnpj;
            supplier.Phone = request.Phone;
            supplier.CellPhone = request.CellPhone;
            supplier.Active = request.Active;

            supplier.Address.ZipCode = request.Address.ZipCode;
            supplier.Address.StreetAddress = request.Address.StreetAddress;
            supplier.Address.Number = request.Address.Number;
            supplier.Address.Complement = request.Address.Complement;
            supplier.Address.Neighborhood = request.Address.Neighborhood;
            supplier.Address.City = request.Address.City;
            supplier.Address.State = request.Address.State;

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();

            var response = new SupplierResponse(
                supplier.Id, supplier.Name, supplier.Trade, supplier.Contact, supplier.Email, supplier.Cnpj,
                supplier.Phone, supplier.CellPhone, supplier.Active,
                new AddressResponse(supplier.Address.Id, supplier.Address.ZipCode, supplier.Address.StreetAddress,
                    supplier.Address.Number, supplier.Address.Complement, supplier.Address.Neighborhood,
                    supplier.Address.City, supplier.Address.State, supplier.Address.Country));

            return response;
        }

        public async Task DeleteAsync(Guid id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == id);

            if (supplier is null)
                throw new EntityNotFoundException($"O fornecedor com o ID: {id} não existe.");

            supplier.Active = false;

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CnpjAlreadyRegistered(string cnpj)
        {
            return await _context.Suppliers.Where(x => x.Cnpj == cnpj).AnyAsync();
        }
        private async Task<bool> EmailAlreadyRegistered(string email)
        {
            return await _context.Employees.Where(x => x.Email == email).AnyAsync();
        }
    }
}
