using MediatR;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Commands
{
    public class UpsertToDoTaskCommand : IRequest<int>
    {
        public ToDoTaskDto TaskDto { get; set; }
    }
}