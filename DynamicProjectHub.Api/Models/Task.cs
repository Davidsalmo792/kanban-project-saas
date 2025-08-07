using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DynamicProjectHub.Api.Models


{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        [ForeignKey("ColumnId")]
        public TaskColumn Column { get; set; } = default!;

        public int ColumnId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = default!;

        public int ProjectId { get; set; }

        [ForeignKey("AssignedToId")]
        public User? AssignedTo { get; set; }

        public int? AssignedToId { get; set; }
    }
}