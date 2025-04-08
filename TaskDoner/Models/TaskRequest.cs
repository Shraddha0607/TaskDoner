using System.ComponentModel.DataAnnotations;

namespace TaskDoner.Models;

public class TaskRequest
{
    [Required]
    [StringLength(30, ErrorMessage = "Name must be upto 30 characters.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabets allowed!")]
    public string Name { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Description must be upto 100 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Only alphanumeric with space  allowed!")]
    public string Description { get; set; }
}