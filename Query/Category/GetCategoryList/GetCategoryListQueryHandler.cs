using AutoMapper;
using DemoWeb.API.Messaging;
using DemoWeb.API.Models.DTO;
using DemoWeb.API.Repositories.Interface;
using DemoWeb.API.Shared;

namespace DemoWeb.API.Query.Category.GetCategoryList
{
    public class GetCategoryListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper) : IQueryHandler<GetCategoryListQuery, IEnumerable<CategoryDto>>
    {
        public async Task<Result<IEnumerable<CategoryDto>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var listCategories = await categoryRepository.GetCategories(cancellationToken);
            var response = listCategories.Select(mapper.Map<CategoryDto>);
            return Result.Success(response);
        }
    }
}
