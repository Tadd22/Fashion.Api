using Microsoft.AspNetCore.Mvc;
using Fashion.Api.Data;
using Fashion.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadyToWearController : ControllerBase
    {
        private readonly FashionContext _context;

        public ReadyToWearController(FashionContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadyToWear>>> GetReadyToWearItems()
        {
            return await _context.ReadyToWearItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadyToWear>> GetReadyToWearItem(int id)
        {
            var item = await _context.ReadyToWearItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ReadyToWear>> CreateReadyToWearItem(ReadyToWear item)
        {
            _context.ReadyToWearItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReadyToWearItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReadyToWearItem(int id, ReadyToWear item)
        {
            if (id != item.Id)
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
                if (!_context.ReadyToWearItems.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteReadyToWearItem(int id)
        {
            var item = await _context.ReadyToWearItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.ReadyToWearItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}