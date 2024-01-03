using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
	public class TaskDbContext : DbContext
	{
		public TaskDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<ToDoTask> ToDoTasks { get; set; }
	}
}
