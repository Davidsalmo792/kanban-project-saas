using DynamicProjectHub.Api.Models;
using Microsoft.EntityFrameworkCore;
using ModelsTask = DynamicProjectHub.Api.Models.Task;

namespace DynamicProjectHub.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskColumn> TaskColumns { get; set; }
        public DbSet<ModelsTask> Tasks { get; set; }
        public DbSet<UserProjectRole> UserProjectRoles { get; set; }
    }
}