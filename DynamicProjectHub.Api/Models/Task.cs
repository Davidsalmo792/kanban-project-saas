using System.ComponentModel.DataAnnotations;

namespace DynamicProjectHub.Api.Models
{
    // This model represents a single task on the Kanban board.
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string? Description { get; set; } // Added description to match frontend

        [Required]
        public string Status { get; set; } // Added status to match frontend (e.g., To Do, Doing, Done)

        public string AssignedTo { get; set; } // Added AssignedTo string

        public int AssignedToId { get; set; } // Added a foreign key for the User model

        // This is a foreign key to link the task to a specific column.
        public int ColumnId { get; set; }

        // This is a navigation property to the associated TaskColumn
        public TaskColumn? Column { get; set; }
    }
}
