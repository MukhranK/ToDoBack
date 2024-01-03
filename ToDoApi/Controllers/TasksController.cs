using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class TasksController : Controller
	{
		private readonly TaskDbContext _db;

		public TasksController(TaskDbContext db) 
		{
			_db = db;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTAsks()
		{
			var tasks = await _db.ToDoTasks.ToListAsync();
			return Ok(tasks); 
		}

		[HttpPost]
		public async Task<IActionResult> AddTask([FromBody] ToDoTask task)
		{
			task.Id = Guid.NewGuid();

			await _db.ToDoTasks.AddAsync(task);
			await _db.SaveChangesAsync();

			return Ok(task);
		}

		[HttpGet]
		[Route("{id}")]

		public async Task<IActionResult> GetTask([FromRoute] Guid id)
		{
			var task = await _db.ToDoTasks.FirstOrDefaultAsync(x => x.Id == id);

			if (task == null)
			{
				return NotFound();
			}

			return Ok(task);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateTask([FromRoute] Guid id, ToDoTask updateTask)
		{
			var task = await _db.ToDoTasks.FindAsync(id);

			if (task == null)
			{
				return NotFound();
			}

			task.TaskAuthor = updateTask.TaskAuthor;
			task.TaskDescription = updateTask.TaskDescription;
			await _db.SaveChangesAsync();
			return Ok(task);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DalateTask([FromRoute] Guid id)
		{
			var task = await _db.ToDoTasks.FindAsync(id);

			if(task == null)
			{
				return NotFound();
			}

			_db.ToDoTasks.Remove(task);
			await _db.SaveChangesAsync();
		
			return Ok(task);
		}
	}
}
