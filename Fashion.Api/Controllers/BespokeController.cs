using Microsoft.AspNetCore.Mvc;
using Fashion.Api.Data;
using Fashion.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fashion.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BespokeController : ControllerBase
	{
		private readonly FashionContext _context;

		public BespokeController(FashionContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Bespoke>>> GetBespokeItems()
		{
			return await _context.BespokeItems.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Bespoke>> GetBespokeItem(int id)
		{
			var item = await _context.BespokeItems.FindAsync(id);

			if (item == null)
			{
				return NotFound();
			}

			return item;
		}

		[HttpPost]
		public async Task<ActionResult<Bespoke>> CreateBespokeItem(Bespoke item)
		{
			_context.BespokeItems.Add(item);
			await _context.SaveChangesAsync();
			return CreatedAtAction(nameof(GetBespokeItem), new { id = item.BespokeID}, item);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBespokeItem(int id, Bespoke item)
		{
			if (id != item.BespokeID)
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
				if (!_context.BespokeItems.Any(e => e.BespokeID == id))
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
		public async Task<IActionResult> DeleteBespokeItem(int id)
		{
			var item = await _context.BespokeItems.FindAsync(id);
			if (item == null)
			{
				return NotFound();
			}

			_context.BespokeItems.Remove(item);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}