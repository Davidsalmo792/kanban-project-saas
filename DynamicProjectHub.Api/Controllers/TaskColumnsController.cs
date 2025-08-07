using DynamicProjectHub.Api.Data;
using DynamicProjectHub.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicProjectHub.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TaskColumnsController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public TaskColumnsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: api/TaskColumns
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TaskColumn>>> GetTaskColumns()
		{
			return await _context.TaskColumns.ToListAsync();
		}

		// GET: api/TaskColumns/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TaskColumn>> GetTaskColumn(int id)
		{
			var taskColumn = await _context.TaskColumns.FindAsync(id);

			if (taskColumn == null)
			{
				return NotFound();
			}

			return taskColumn;
		}

		// PUT: api/TaskColumns/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutTaskColumn(int id, TaskColumn taskColumn)
		{
			if (id != taskColumn.Id)
			{
				return BadRequest();
			}

			_context.Entry(taskColumn).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TaskColumnExists(id))
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

		// POST: api/TaskColumns
		[HttpPost]
		public async Task<ActionResult<TaskColumn>> PostTaskColumn(TaskColumn taskColumn)
		{
			_context.TaskColumns.Add(taskColumn);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTaskColumn), new { id = taskColumn.Id }, taskColumn);
		}

		// DELETE: api/TaskColumns/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTaskColumn(int id)
		{
			var taskColumn = await _context.TaskColumns.FindAsync(id);
			if (taskColumn == null)
			{
				return NotFound();
			}

			_context.TaskColumns.Remove(taskColumn);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TaskColumnExists(int id)
		{
			return _context.TaskColumns.Any(e => e.Id == id);
		}
	}
}
