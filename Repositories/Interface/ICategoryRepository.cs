using DemoWeb.API.Models.Domain;

namespace DemoWeb.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
    }
}
