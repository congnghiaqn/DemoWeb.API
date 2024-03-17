using DemoWeb.API.Messaging;

namespace DemoWeb.API.Command.Category.DeleteCategory
{
    public record DeleteCategoryCommand(Guid Id) : ICommand;
}
