namespace DemoWeb.API.Models.DTO
{
    public class CreateCategoryRequestDto
    {
        public required string Name { get; set; }
        public required string UrlHandle { get; set; }
    }
}
