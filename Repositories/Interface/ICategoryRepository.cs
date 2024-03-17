using DemoWeb.API.Models.Domain;

namespace DemoWeb.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        void CreateAsync(Category category);
        Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken = default);
        Task<Category?> GetCategory(Guid id, CancellationToken cancellationToken = default);
        void UpdateCatergory(Category category);
        void DeleteCatergory(Category category);
    }
}
