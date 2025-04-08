using Microsoft.EntityFrameworkCore;
using TaskDoner.Models;

namespace TaskDoner.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TaskModel> Tasks { get; set; }
}