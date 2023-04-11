using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IProductEntryService
    {
        Task<List<ProductEntryHeaderListResponse>> GetAllAsync();
        Task ProductEntryAddAsync(CreateProductEntryHeaderRequest request);
    }
}
