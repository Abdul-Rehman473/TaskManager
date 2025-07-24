using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.DTOs;
using TaskManager.Application.Queries;

namespace TaskManager.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoTaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _mediator.Send(new GetAllToDoTasksQuery());
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving tasks.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _mediator.Send(new GetToDoTaskByIdQuery { Id = id });
                return task == null ? NotFound() : Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the task.");
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody] ToDoTaskDto taskDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (taskDto.Id.HasValue && taskDto.Id != 0)
                {
                    var id = await _mediator.Send(new UpsertToDoTaskCommand { TaskDto = taskDto });
                    return NoContent();
                }
                var newId = await _mediator.Send(new UpsertToDoTaskCommand { TaskDto = taskDto });
                return CreatedAtAction(nameof(GetById), new { id = newId }, taskDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the task.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteToDoTaskCommand { Id = id });
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the task.");
            }
        }
    }
}


