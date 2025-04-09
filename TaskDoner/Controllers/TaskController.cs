using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskDoner.Exceptions;
using TaskDoner.Models;
using TaskDoner.Services;

namespace TaskDoner.Controllers;

[ApiController]
[Route("/[controller]")]
[Authorize]
public class TaskController : ControllerBase
{
    private readonly ITaskService taskService ;
    private readonly ILogger logger;

    public TaskController(ITaskService taskService,
        ILogger<TaskController> logger)
    {
        this.taskService = taskService;
        this.logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Add(TaskRequest taskRequest)
    {
        var result = await taskService.AddAsync(taskRequest);
        return Ok(result);
    }

    [HttpGet("/getById")]
    public async Task<ActionResult<TaskModel>> Get(int id)
    {
        try
        {
            TaskModel task = await taskService.GetAsync(id);
            return Ok(task);
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
            logger.LogError(ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest(null);
        }
    }

    [HttpPut]
    public async Task<ActionResult<string>> Update(int id, TaskRequest taskRequest)
    {
        try
        {
            var message = await taskService.UpdateAsync(id, taskRequest);
            return Ok(message);
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
            logger.LogError(ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest(null);
        }
    }

    [HttpGet("/getAll")]
    public async Task<ActionResult<IEnumerable<TaskModel>>> GetAll()
    {
        try
        {
            var message = await taskService.GetAll();
            return Ok(message);
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
            logger.LogError(ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest(null);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<string>> Delete(int id)
    {
        try
        {
            var message = await taskService.DeleteAsync(id);
            return Ok(message);
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
            logger.LogError(ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest(null);
        }
    }

    [HttpPut("/markcomplete")]
    public async Task<ActionResult<string>> MarkCompleted(int id)
    {
        try
        {
            var message = await taskService.MarkTaskCompletedAsync(id);
            return Ok(message);
        }
        catch (Exception ex)
        {
            if (ex is CustomException)
            {
                return BadRequest(ex.Message);
            }
            logger.LogError(ex.Message);
            logger.LogError(ex.StackTrace);
            return BadRequest(null);
        }
    }
}