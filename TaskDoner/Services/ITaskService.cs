using TaskDoner.Models;

namespace TaskDoner.Services;

public interface ITaskService
{
    public Task<string> AddAsync(TaskRequest taskRequest);

    public Task<TaskModel> GetAsync(int id);

    Task<string> UpdateAsync(int id, TaskRequest taskRequest);

    Task<IEnumerable<TaskModel>> GetAll();

    Task<string> DeleteAsync(int id);

    Task<string> MarkTaskCompletedAsync(int id);
}