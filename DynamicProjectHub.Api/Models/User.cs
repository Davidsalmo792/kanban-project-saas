using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicProjectHub.Api.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        // Navigation property for Project roles
        public List<UserProjectRole> ProjectRoles { get; set; } = new List<UserProjectRole>();

        // Navigation property for Projects owned
        public List<Project> OwnedProjects { get; set; } = new List<Project>();

        // Navigation property for Tasks assigned
        public List<Task> AssignedTasks { get; set; } = new List<Task>();
    }
}