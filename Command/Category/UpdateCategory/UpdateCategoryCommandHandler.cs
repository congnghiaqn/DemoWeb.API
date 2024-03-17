using DemoWeb.API.Messaging;
using DemoWeb.API.Repositories.Interface;
using DemoWeb.API.Shared;

namespace DemoWeb.API.Command.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateCategoryCommand>
    {
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategory(request.Id, cancellationToken);
            if (category is null)
            {
                return Result.Failure(new Error("Category.NotFound", "Category not exist."));
            }
            category.Name = request.Name;
            category.UrlHandle = request.UrlHandle;
            categoryRepository.UpdateCatergory(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
