using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWeb.API.Data;
using DemoWeb.API.Models.Domain;
using DemoWeb.API.Models.DTO;

namespace DemoWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(AppDbContext context) : ControllerBase
    {

        // GET: api/Catergories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        // GET: api/Catergories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var catergory = await context.Categories.FindAsync(id);

            if (catergory == null)
            {
                return NotFound();
            }

            return catergory;
        }

        // PUT: api/Catergories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatergory(Guid id, Category catergory)
        {
            if (id != catergory.Id)
            {
                return BadRequest();
            }

            context.Entry(catergory).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatergoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Catergories
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCatergory(CreateCategoryRequestDto request)
        {
            var category = new Category { Name = request.Name, UrlHandle = request.UrlHandle };
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);
        }

        // DELETE: api/Catergories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatergory(Guid id)
        {
            var catergory = await context.Categories.FindAsync(id);
            if (catergory == null)
            {
                return NotFound();
            }

            context.Categories.Remove(catergory);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool CatergoryExists(Guid id)
        {
            return context.Categories.Any(e => e.Id == id);
        }
    }
}
