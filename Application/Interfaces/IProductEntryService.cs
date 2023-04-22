using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IProductEntryService
    {
        Task<List<ProductEntryHeaderListResponse>> GetAllAsync();
        public Task<ProductCodeEntryResponse?> GetProductByCodeAsync(string code);
        Task<ProductEntryHeaderResponse?> GetByCodeAsync(string code);
        Task ProductEntryAddAsync(CreateProductEntryHeaderRequest request);
    }
}
