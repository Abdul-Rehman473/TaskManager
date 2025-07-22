using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Application.Commands;
using TaskManager.Application.DTOs;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers
{
    public class CreateToDoTaskHandler : IRequestHandler<CreateToDoTaskCommand, int>
    {
        private readonly IToDoTaskRepository _repository;
        private readonly IMapper _mapper;

        public CreateToDoTaskHandler(IToDoTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new ToDoTask(
                request.TaskDto.Title,
                request.TaskDto.Description,
                null, 
                request.TaskDto.IsCompleted,
                request.TaskDto.CompletedAt
            );
            await _repository.AddAsync(task);
            return task.Id;
        }
    }
}