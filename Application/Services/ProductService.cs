using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly CliVetDogsCatsContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(CliVetDogsCatsContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<ProductListResponse>?> GetAllAsync()
        {
            return await _context.Products.Include("Category").Include("Brand")
                .Where(x => x.Active == true)
                .OrderBy(x => x.Category.Name).ThenBy(x => x.Brand.Name).ThenBy(x => x.Name)
                .Select(p => new ProductListResponse(
                    p.Id, p.Name, p.Brand.Name, p.Category.Name, p.CostValue, p.SaleValue))                
                .AsNoTracking().ToListAsync();
        }

        public async Task<ProductResponse?> GetByIdAsync(Guid id)
        {
            //var product = await _context.Products.Include("Category").Include("Brand")
            //    .Where(x => x.Active == true && x.Id == id)
            //    .Select(p => new ProductResponse(
            //        p.Id, p.Code, p.Name, p.Description, p.CostValue, p.ProfitMargin, p.SaleValue, p.StockQuantity,
            //        p.CategoryId, p.BrandId, p.Active))
            //    .AsNoTracking().FirstOrDefaultAsync();

            var product = await _context.Products
                .Where(x => x.Active == true && x.Id == id)
                .Select(p => new ProductResponse(
                    p.Id, p.Code, p.Name, p.Description, Math.Round(p.CostValue, 2), p.ProfitMargin, p.SaleValue, p.StockQuantity, 
                    p.CategoryId, p.BrandId, p.Active))
                .AsNoTracking().FirstOrDefaultAsync();

            if (product is null)
                throw new EntityNotFoundException($"O produto com o ID: {id} não existe.");

            //var response = new ProductResponse(
            //    product.Id, product.Code, product.Name, product.Description, product.CostValue,
            //    product.ProfitMargin, product.SaleValue, product.StockQuantity, 
            //    product.CategoryId, product.BrandId, product.Active);

            return product;
        }

        public async Task<ProductResponse?> GetByCodeAsync(string code)
        {
            var product = await _context.Products
                .Where(x => x.Active == true && x.Code == code)
                .Select(p => new ProductResponse(
                    p.Id, p.Code, p.Name, p.Description, p.CostValue, p.ProfitMargin, p.SaleValue, p.StockQuantity,
                    p.CategoryId, p.BrandId, p.Active))
                .AsNoTracking().FirstOrDefaultAsync();

            if (product is null)
                throw new EntityNotFoundException($"O produto com o código: {code} não existe.");

            //var response = new ProductResponse(
            //    product.Id, product.Code, product.Name, product.Description, product.CostValue,
            //    product.ProfitMargin, product.SaleValue, product.StockQuantity,
            //    product.CategoryId, product.BrandId, product.Active);

            return product;
        }

        public async Task<ProductResponse> CreateAsync(CreateProductRequest request)
        {
            if (await CodeAlreadyRegistered(request.Code))
                throw new PropertyBadRequestException(
                    $"Já existe um producto cadastrado como o código: {request.Code}");

            var product = new Product(request.Code, request.Name, request.Description,
                request.CostValue, request.ProfitMargin, request.SaleValue, request.StockQuantity,
                request.CategoryId, request.BrandId);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var response = new ProductResponse(
                product.Id, product.Code, product.Name, product.Description, product.CostValue,
                product.ProfitMargin, product.SaleValue, product.StockQuantity,
                request.CategoryId, request.BrandId, product.Active);

            return response;
        }

        public async Task<ProductResponse> UpdateAsync(UpdateProductRequest request)
        {
            var product = await _context.Products.Include("Category").Include("Brand")
                .Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (product is null)
                throw new EntityNotFoundException($"O produto com o ID: {request.Id} não existe.");

            if (product.Code.Trim() != request.Code.Trim())
            {
                if (await CodeAlreadyRegistered(request.Code))
                    throw new PropertyBadRequestException(
                        $"Já existe um producto cadastrado com o código: {request.Code}");
            }

            product.Code = request.Code;
            product.Name = request.Name;
            product.Description = request.Description;
            product.CostValue = request.CostValue;
            product.ProfitMargin = request.ProfitMargin;
            product.SaleValue = request.SaleValue;  
            product.StockQuantity = request.StockQuantity;
            product.CategoryId = request.CategoryId;
            product.BrandId = request.BrandId;
            product.Active = request.Active;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            var response = new ProductResponse(
                product.Id,
                product.Code,
                product.Name,
                product.Description,
                product.CostValue,
                product.ProfitMargin,
                product.SaleValue,
                product.StockQuantity,
                request.CategoryId,
                request.BrandId,
                product.Active);

            return response;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
                throw new EntityNotFoundException($"O produto com o ID: {id} não existe.");

            product.Active = false;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> CodeAlreadyRegistered(string code)
        {
            return await _context.Products.Where(x => x.Code == code).AnyAsync();
        }
    }
}
