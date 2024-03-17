using DemoWeb.API.Data;
using DemoWeb.API.Repositories.Interface;

namespace DemoWeb.API.Repositories.Implementation
{
    internal sealed class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return context.SaveChangesAsync(cancellationToken);
        }
    }
}
