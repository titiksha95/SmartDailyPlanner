using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDailyPlanner.Models
{
    [Table("PlannerTasks")]
    public class PlannerTask
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage ="Discription cannot exceed 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage ="Due Date is required")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [StringLength(20)]
        public string Priority { get; set; } = "Medium";

        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
