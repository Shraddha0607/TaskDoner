using Microsoft.EntityFrameworkCore;
using TaskDoner.Data;
using TaskDoner.Exceptions;
using TaskDoner.Models;

namespace TaskDoner.Services;

public class TaskService : ITaskService
{
    private readonly TaskDbContext taskDbContext;

    public TaskService(TaskDbContext taskDbContext)
    {
        this.taskDbContext = taskDbContext;
    }

    public async Task<TaskModel> GetAsync(int id)
    {
        var taskModel = await taskDbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        if (taskModel == null)
        {
            throw new CustomException("Invalid id!");
        }
        return taskModel;
    }

    public async Task<string> AddAsync(TaskRequest taskRequest)
    {
        TaskModel model = new TaskModel
        {
            TaskName = taskRequest.Name,
            Details = taskRequest.Description,
            IsCompleted = false
        };

        await taskDbContext.Tasks.AddAsync(model);
        await taskDbContext.SaveChangesAsync();
        return "Task added successfully.";
    }

    public async Task<string> UpdateAsync(int id, TaskRequest taskRequest)
    {
        var existingTask = taskDbContext.Tasks.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (existingTask == null)
        {
            throw new CustomException("Invalid id");
        }
        existingTask.TaskName = taskRequest.Name;
        existingTask.Details = taskRequest.Description;

        taskDbContext.Update(existingTask);
        await taskDbContext.SaveChangesAsync();

        return "Task updated successfully.";
    }

    public async Task<IEnumerable<TaskModel>> GetAll()
    {
        var allTasks = await taskDbContext.Tasks.AsNoTracking().ToListAsync();
        if (!allTasks.Any())
        {
            throw new CustomException("No record found!");
        }
        return allTasks;
    }

    public async Task<string> DeleteAsync(int id)
    {
        var task = await taskDbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (task == null)
        {
            throw new CustomException("Invalid id!");
        }
        taskDbContext.Tasks.Remove(task);
        await taskDbContext.SaveChangesAsync();
        return "Task deleted successfully.";
    }

    public async Task<string> MarkTaskCompletedAsync(int id)
    {
        var task = await taskDbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (task == null)
        {
            throw new CustomException("Invalid Id!");
        }

        task.IsCompleted = true;
        taskDbContext.Update(task);
        await taskDbContext.SaveChangesAsync();
        return "Task marked as completed successfully.";
    }
}