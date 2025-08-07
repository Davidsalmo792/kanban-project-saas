using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DynamicProjectHub.Api.Models

{
    public enum ProjectRole
    {
        Owner,
        Member,
        Viewer
    }

    public class UserProjectRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ProjectRole Role { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = default!;
        public int UserId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = default!;
        public int ProjectId { get; set; }
    }
}