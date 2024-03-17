using DemoWeb.API.Data;
using DemoWeb.API.Models.Domain;
using DemoWeb.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.API.Repositories.Implementation
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        public void CreateAsync(Category category) => context.Categories.Add(category);

        public void DeleteCatergory(Category category) => context.Categories.Remove(category);

        public async Task<IEnumerable<Category>> GetCategories(CancellationToken cancellationToken = default) => await context.Categories.ToListAsync(cancellationToken);

        public async Task<Category?> GetCategory(Guid id, CancellationToken cancellationToken = default) => await context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public void UpdateCatergory(Category category) => context.Categories.Update(category);
    }
}
