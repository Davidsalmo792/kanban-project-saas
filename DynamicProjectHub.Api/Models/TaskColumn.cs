namespace DynamicProjectHub.Api.Models
{
    public class TaskColumn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = default!;

        public int ProjectId { get; set; }

        // Navigation property for tasks in this column
        public List<Task> Tasks { get; set; } = new List<Task>();
    }
}