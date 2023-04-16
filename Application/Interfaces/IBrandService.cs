using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandResponse>?> GetAllAsync();
        Task<List<BrandResponse>?> GetByCategoryIdAsync(Guid categoryId);
    }
}
