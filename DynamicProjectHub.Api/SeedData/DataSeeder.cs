using DynamicProjectHub.Api.Data;
using DynamicProjectHub.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ModelsTask = DynamicProjectHub.Api.Models.Task; // Use an alias to avoid ambiguity

namespace DynamicProjectHub.Api.SeedData
{
	public static class DataSeeder
	{
		public static void SeedDatabase(ApplicationDbContext context)
		{
			context.Database.EnsureCreated();

			if (context.Projects.Any())
			{
				return;   // Database has been seeded
			}

			var projects = new Project[]
			{
				new Project { Title = "Project Alpha", OwnerId = 1 },
				new Project { Title = "Project Beta", OwnerId = 2 },
				new Project { Title = "Project Gamma", OwnerId = 1 }
			};

			context.Projects.AddRange(projects);
			context.SaveChanges();

			var users = new User[]
			{
				new User { Username = "David" },
				new User { Username = "Jane" }
			};
			context.Users.AddRange(users);
			context.SaveChanges();

			var taskColumns = new TaskColumn[]
			{
				new TaskColumn { Title = "To Do", ProjectId = projects[0].Id },
				new TaskColumn { Title = "Doing", ProjectId = projects[0].Id },
				new TaskColumn { Title = "Done", ProjectId = projects[0].Id }
			};
			context.TaskColumns.AddRange(taskColumns);
			context.SaveChanges();

			// Use the alias 'ModelsTask' here to reference your custom Task model
			var tasks = new ModelsTask[]
			{
				new ModelsTask { Title = "Design API", Description = "Plan out the API endpoints for the Kanban board.", AssignedTo = users[0].Username, AssignedToId = users[0].Id, Status = "To Do", ColumnId = taskColumns[0].Id },
				new ModelsTask { Title = "Implement User Authentication", Description = "Write the code for user login and registration.", AssignedTo = users[1].Username, AssignedToId = users[1].Id, Status = "Doing", ColumnId = taskColumns[1].Id },
				new ModelsTask { Title = "Create a new component", Description = "Build the task component for the UI.", AssignedTo = users[0].Username, AssignedToId = users[0].Id, Status = "Done", ColumnId = taskColumns[2].Id }
			};
			context.Tasks.AddRange(tasks);
			context.SaveChanges();
		}
	}
}
