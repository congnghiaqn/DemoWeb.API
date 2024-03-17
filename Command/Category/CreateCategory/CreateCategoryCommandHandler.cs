using DemoWeb.API.Messaging;
using DemoWeb.API.Repositories.Interface;
using DemoWeb.API.Shared;

namespace DemoWeb.API.Command.Category.CreateCategory
{
    public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository) : ICommandHandler<CreateCategoryCommand>
    {
        public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Models.Domain.Category() { Name = request.Name, UrlHandle = request.UrlHandle };
            categoryRepository.CreateAsync(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
