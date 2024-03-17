using DemoWeb.API.Messaging;
using DemoWeb.API.Models.DTO;
using DemoWeb.API.Repositories.Interface;
using DemoWeb.API.Shared;

namespace DemoWeb.API.Query.Category.GetCategoryById
{
    public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        public async Task<Result<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await categoryRepository.GetCategory(request.Id, cancellationToken);
            if (category is null)
            {
                return Result.Failure<CategoryDto>(new Error("Category.NotFound", "Category not exist."));
            }
            var response = new CategoryDto() { Name = category.Name, UrlHandle = category.UrlHandle, Id = category.Id };
            return Result.Success(response);
        }
    }
}