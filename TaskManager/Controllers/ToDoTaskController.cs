using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.DTOs;
using TaskManager.Application.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var tasks = await _mediator.Send(new GetAllToDoTasksQuery());
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _mediator.Send(new GetToDoTaskByIdQuery { Id = id });
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateToDoTaskDto taskDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _mediator.Send(new CreateToDoTaskCommand { TaskDto = taskDto });
            return CreatedAtAction(nameof(GetById), new { id }, taskDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ToDoTaskDto taskDto)
        {
            if (id != taskDto.Id || !ModelState.IsValid) return BadRequest();
            await _mediator.Send(new UpdateToDoTaskCommand { TaskDto = taskDto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteToDoTaskCommand { Id = id });
            return NoContent();
        }
    }
}