using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Commands
{
    public class UpdateToDoTaskCommand : IRequest
    {
        public ToDoTaskDto TaskDto { get; set; }
    }
}
