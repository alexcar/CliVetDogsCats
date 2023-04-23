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
    public class ProductEntryService : IProductEntryService
    {
        private readonly CliVetDogsCatsContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductEntryService(CliVetDogsCatsContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<ProductEntryHeaderListResponse>> GetAllAsync()
        {
            var response = await _context.ProductEntryHeaders.Include("Employee").Include("Supplier")
                .Where(x => x.Active == true)
                .OrderBy(x => x.Code)
                .Select(x => new ProductEntryHeaderListResponse(x.Id, x.Code, x.Employee.Name, x.Supplier.Name, x.CreatedDate, 
                    x.ProductsEntry.Sum(p => p.Quantity * p.CostValue)))                
                .AsNoTracking().ToListAsync();

            // https://learn.microsoft.com/en-us/ef/core/querying/complex-query-operators
            //var query = from productEntryHeader in _context.ProductEntryHeaders
            //            join employee in _context.Employees
            //                on productEntryHeader.EmployeeId equals employee.Id
            //            join supplier in _context.Suppliers
            //                on productEntryHeader.SupplierId equals supplier.Id
            //            join productEntry in _context.ProductEntries
            //                on productEntryHeader.Id equals productEntry.ProductEntryHeaderId
            //            // group productEntry by productEntry.Id
            //            // into g
            //            select new { productEntryHeader }

            return response;
        }

        public async Task<ProductEntryHeaderResponse?> GetByCodeAsync(string code)
        {
            var productEntryHeader = await _context.ProductEntryHeaders.Include("Employee").Include("Supplier").Include("ProductEntry")
                .Where(x => x.Active == true && x.Code == code)
                .OrderBy(x => x.Code)
                .Select(x => new ProductEntryHeaderResponse(x.Id, x.Code, x.Employee.Id, x.Supplier.Id,
                    x.ProductsEntry
                        .Select(p => new ProductEntryResponse(
                            p.Id, 
                            p.ProductEntryHeaderId, 
                            p.ProductId, p.Product.Code, p.Product.Name, p.CostValue, p.Quantity)).ToList()
                ))
                .AsNoTracking().FirstOrDefaultAsync();

            if (productEntryHeader is null)
                throw new EntityNotFoundException($"A entrada de produtos com o código: {code} não existe.");

            return productEntryHeader;
        }

        public async Task<ProductCodeEntryResponse?> GetProductByCodeAsync(string code)
        {
            var product = await _context.Products.Include("Category").Include("Brand")
                .Where(x => x.Code == code)
                .Select(p => new ProductCodeEntryResponse(p.Id, p.Code, p.Name, p.Category.Name, p.Brand.Name, p.CostValue))
                .AsNoTracking().FirstOrDefaultAsync();

            if (product is null)
                throw new EntityNotFoundException($"O produto com o código: {code} não existe.");

            return product;
        }

        public async Task ProductEntryAddAsync(CreateProductEntryHeaderRequest request)
        {
            if (!request.ProductsEntry.Any())
                throw new PropertyBadRequestException("É obrigatório informar pelo menos um produto.");

            var productEntryHeader = new ProductEntryHeader(request.Code, request.EmployeeId, request.SupplierId,
                request.ProductsEntry.Select(p => new ProductEntry(p.ProductId, p.CostValue, p.Quantity)));

            await _context.ProductEntryHeaders.AddAsync(productEntryHeader);

            foreach (var item in request.ProductsEntry) 
            {
                var product = _context.Products.Where(x => x.Id == item.ProductId).FirstOrDefault();

                if (product is null)
                    throw new EntityNotFoundException($"O produto com o ID: {item.ProductId} não existe.");

                // Update cost value                
                if (product.CostValue != item.CostValue)
                    product.CostValue = item.CostValue;

                // update stock
                product.StockQuantity += item.Quantity;

                _context.Products.Update(product);
            }            
            
            await _context.SaveChangesAsync();
        }        
    }
}
