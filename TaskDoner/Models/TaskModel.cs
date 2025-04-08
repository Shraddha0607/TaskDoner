using System.ComponentModel.DataAnnotations;

namespace TaskDoner.Models;

public class TaskModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "Name must be upto 30 characters.")]
    public string TaskName { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Description must be upto 100 characters.")]
    public string Details { get; set; }

    public Boolean IsCompleted { get; set; }
}