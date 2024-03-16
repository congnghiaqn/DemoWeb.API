using DemoWeb.API.Data;
using DemoWeb.API.Models.Domain;
using DemoWeb.API.Repositories.Interface;

namespace DemoWeb.API.Repositories.Implementation
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public async Task<Category> CreateAsync(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }
    }
}
