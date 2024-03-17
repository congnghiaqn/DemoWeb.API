using DemoWeb.API.Messaging;

namespace DemoWeb.API.Command.Category.CreateCategory
{
    public record CreateCategoryCommand(string Name, string UrlHandle) : ICommand;
}
