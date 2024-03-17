using Microsoft.AspNetCore.Mvc;
using DemoWeb.API.Models.Domain;
using MediatR;
using DemoWeb.API.Command.Category.CreateCategory;
using DemoWeb.API.Command.Category.UpdateCategory;
using DemoWeb.API.Query.Category.GetCategoryList;
using DemoWeb.API.Command.Category.DeleteCategory;
using DemoWeb.API.Query.Category.GetCategoryById;

namespace DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ISender sender) : ControllerBase
    {

        // GET: api/Catergories
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var query = new GetCategoryListQuery();
            var result = await sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest();
        }

        // GET: api/Catergories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        // PUT: api/Catergories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> UpdateCatergory([FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);
            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }

        // POST: api/Catergories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCatergory([FromBody] CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await sender.Send(request, cancellationToken);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        // DELETE: api/Catergories/5
        [HttpDelete]
        public async Task<IActionResult> DeleteCatergory([FromBody] DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await sender.Send(command, cancellationToken);
            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }
    }
}
