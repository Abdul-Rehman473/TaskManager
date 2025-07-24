//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using TaskManager.Application.Commands;
//using TaskManager.Application.DTOs;
//using TaskManager.Application.Queries;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace TaskManager.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ToDoTaskController : ControllerBase
//    {
//        private readonly IMediator _mediator;

//        public ToDoTaskController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var tasks = await _mediator.Send(new GetAllToDoTasksQuery());
//            return Ok(tasks);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var task = await _mediator.Send(new GetToDoTaskByIdQuery { Id = id });
//            if (task == null) return NotFound();
//            return Ok(task);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateToDoTaskDto taskDto)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);
//            var id = await _mediator.Send(new CreateToDoTaskCommand { TaskDto = taskDto });
//            return CreatedAtAction(nameof(GetById), new { id }, taskDto);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, [FromBody] ToDoTaskDto taskDto)
//        {
//            if (id != taskDto.Id || !ModelState.IsValid) return BadRequest();
//            await _mediator.Send(new UpdateToDoTaskCommand { TaskDto = taskDto });
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            await _mediator.Send(new DeleteToDoTaskCommand { Id = id });
//            return NoContent();
//        }
//    }
//}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.DTOs;
using TaskManager.Application.Queries;
using System;
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


