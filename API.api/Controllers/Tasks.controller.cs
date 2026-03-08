using Microsoft.AspNetCore.Mvc;
using Services.Aplication.Models;
using Services.Aplication.Communication.Requests;
using Services.Aplication.Repository;
namespace manager.API.Controllers;



[Route("api/[controller]")]
[ApiController]

public class TasksController:ControllerBase 
{
  private readonly DBRepository _dbRepository;
  public TasksController(DBRepository dbRepository) {
    _dbRepository = dbRepository;
  }

  [HttpGet]
  [ProducesResponseType(typeof(List<TaskModel>), StatusCodes.Status200OK)]
  public IActionResult Get() {
    return StatusCode(200, new { status = "OK", data = _dbRepository.Tasks });
  }

  [HttpPost]
  [ProducesResponseType(typeof(TaskModel), StatusCodes.Status201Created)]
  public IActionResult Post([FromBody] RequestRegisterTaskJson task) {
    if (task == null || string.IsNullOrEmpty(task.Title) || string.IsNullOrEmpty(task.Description) || task.DueDate == null || task.Priority == null || task.Status == null) {
      return BadRequest(new { status = "Invalid request" });
    }

    var newTask = new TaskModel {
      Id = Guid.NewGuid(),
      Name = task.Title,
      Description = task.Description ?? string.Empty,
      DueDate = task.DueDate,
      Priority = task.Priority,
      Status = task.Status
    };
    _dbRepository.Tasks.Add(newTask);
    return Created(string.Empty, newTask);
  }

  [HttpPut]
  [Route("{id}")]
  [ProducesResponseType(typeof(TaskModel), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
  public IActionResult Put(Guid id, [FromBody] RequestRegisterTaskJson request) {
    var task = _dbRepository.Tasks.FirstOrDefault(t => t.Id == id );
    if (task == null) {
      return NotFound(new { status = "Task not found" });
    }
    task.Name = request.Title;
    task.Description = request.Description ?? string.Empty;
    task.DueDate = request.DueDate;
    task.Priority = request.Priority;
    task.Status = request.Status;
    
    return Ok(task);
  }
  
  [HttpDelete]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
  [Route("{id}")]
  public IActionResult Delete(Guid id) {
    var task = _dbRepository.Tasks.FirstOrDefault(t => t.Id == id );
    if (task == null) {
      return NotFound(new { status = "Task not found" });
    }
    _dbRepository.Tasks.Remove(task);
    return NoContent();
    
  }
}