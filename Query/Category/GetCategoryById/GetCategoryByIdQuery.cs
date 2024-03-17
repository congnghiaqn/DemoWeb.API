using DemoWeb.API.Messaging;
using DemoWeb.API.Models.DTO;

namespace DemoWeb.API.Query.Category.GetCategoryById
{
    public record GetCategoryByIdQuery(Guid Id) : IQuery<CategoryDto>;
}