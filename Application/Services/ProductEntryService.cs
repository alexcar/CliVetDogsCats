using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Exceptions;
using Application.Interfaces;
using Azure.Core;
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
            var response = await _context.ProductEntryHeaders.Include("Employee").Include("Supplier").Include("ProductEntry")
                .Where(x => x.Active == true)
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

        public async Task ProductEntryAddAsync(CreateProductEntryHeaderRequest request)
        {
            if (!request.ProductsEntry.Any())
                throw new PropertyBadRequestException("É obrigatório informar pelo menos um produto.");

            var productEntryHeader = new ProductEntryHeader(request.Code, request.EmployeeId, request.SupplierId,
                request.ProductsEntry.Select(p => new ProductEntry(p.CostValue, p.Quantity)));            
            
            foreach(var item in request.ProductsEntry) 
            { 
                UpdateStock(item.ProductId, item.Quantity);
            }

            await _context.ProductEntryHeaders.AddAsync(productEntryHeader);
            await _context.SaveChangesAsync();
        }

        private void UpdateStock(Guid productId, int quantity)
        {
            var product = _context.Products.Where(x => x.Id == productId).FirstOrDefault();

            if (product is null)
                throw new EntityNotFoundException($"O produto com o ID: {productId} não existe.");

            product.StockQuantity += quantity;
            _context.Products.Update(product);
        }
    }
}
