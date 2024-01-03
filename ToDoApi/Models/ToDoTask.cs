using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
	public class ToDoTask
	{
		public Guid Id { get; set; }

		public string TaskAuthor { get; set; }

		public string TaskDescription { get; set; }
	}
}
