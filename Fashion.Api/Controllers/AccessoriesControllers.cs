using Microsoft.AspNetCore.Mvc;
using Fashion.Api.Data;
using Fashion.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoriesController : ControllerBase
    {
        private readonly FashionContext _context;

        public AccessoriesController(FashionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accessories>>> GetAccessoriesItems()
        {
            return await _context.AccessoriesItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accessories>> GetAccessoriesItem(int id)
        {
            var item = await _context.AccessoriesItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Accessories>> CreateAccessoriesItem(Accessories item)
        {
            _context.AccessoriesItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccessoriesItem), new { id = item.AccessoriesID }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccessoriesItem(int id, Accessories item)
        {
            if (id != item.AccessoriesID)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AccessoriesItems.Any(e => e.AccessoriesID == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessoriesItem(int id)
        {
            var item = await _context.AccessoriesItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.AccessoriesItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}