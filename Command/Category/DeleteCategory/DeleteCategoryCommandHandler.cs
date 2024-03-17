using DemoWeb.API.Messaging;
using DemoWeb.API.Repositories.Interface;
using DemoWeb.API.Shared;

namespace DemoWeb.API.Command.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteCategoryCommand>
    {
        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategory(request.Id, cancellationToken);
            if (category is null)
            {
                return Result.Failure(new Error("Category.NotFound", "Category not exist."));
            }
            categoryRepository.DeleteCatergory(category);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
