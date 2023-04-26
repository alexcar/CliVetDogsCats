using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IProductEntryService
    {
        public Task<List<ProductEntryHeaderListResponse>> GetAllAsync();
        public Task<ProductEntryHeaderListResponse?> GetByIdAsync(Guid id);
        public Task<ProductCodeEntryResponse?> GetProductByCodeAsync(string code);
        public Task<ProductEntryHeaderResponse?> GetByCodeAsync(string code);
        public Task ProductEntryAddAsync(CreateProductEntryHeaderRequest request);
    }
}
