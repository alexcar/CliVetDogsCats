using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponse>?> GetAllAsync();
    }
}
