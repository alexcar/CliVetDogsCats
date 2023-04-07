using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductListResponse>?> GetAllAsync();
        public Task<ProductResponse?> GetByIdAsync(Guid id);        
        public Task<ProductResponse> CreateAsync(CreateProductRequest request);
        public Task<ProductResponse> UpdateAsync(UpdateProductRequest request);
        public Task DeleteAsync(Guid id);
    }
}
