using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface ISupplierService
    {
        public Task<List<SupplierListResponse>?> GetAllAsync();
        public Task<SupplierResponse?> GetByIdAsync(Guid id);
        public Task<List<SupplierListResponse>?> GetByTermAsync(string term);
        public Task<SupplierResponse> CreateAsync(CreateSupplierRequest request);
        public Task<SupplierResponse> UpdateAsync(UpdateSupplierRequest request);
        public Task DeleteAsync(Guid id);
    }
}
