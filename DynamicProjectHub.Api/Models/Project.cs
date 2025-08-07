namespace DynamicProjectHub.Api.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [ForeignKey("OwnerId")]
        public User Owner { get; set; } = default!;

        public int OwnerId { get; set; }

        // Navigation property for User roles
        public List<UserProjectRole> UserRoles { get; set; } = new List<UserProjectRole>();

        // Navigation properties for related entities
        public List<TaskColumn> TaskColumns { get; set; } = new List<TaskColumn>();
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}