using DemoWeb.API.Messaging;

namespace DemoWeb.API.Command.Category.UpdateCategory
{
    public record UpdateCategoryCommand(Guid Id,string Name, string UrlHandle) : ICommand;
}