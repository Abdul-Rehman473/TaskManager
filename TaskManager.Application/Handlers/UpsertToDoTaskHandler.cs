using AutoMapper;
using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers
{
    public class UpsertToDoTaskHandler : IRequestHandler<UpsertToDoTaskCommand, int>
    {
        private readonly IToDoTaskRepository _repository;
        private readonly IMapper _mapper;

        public UpsertToDoTaskHandler(IToDoTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpsertToDoTaskCommand request, CancellationToken cancellationToken)
        {
            if (request.TaskDto == null)
                throw new ArgumentNullException(nameof(request.TaskDto));

            if (request.TaskDto.Id.HasValue)
            {
                var task = await _repository.GetbyIdAsync(request.TaskDto.Id.Value);
                if (task != null)
                {
                    task.SetTitle(request.TaskDto.Title);
                    task.SetDescription(request.TaskDto.Description);
                    if (request.TaskDto.IsCompleted && !task.IsCompleted)
                        task.MarkComplete();
                    else if (!request.TaskDto.IsCompleted && task.IsCompleted)
                        task.MarkIncomplete();
                    await _repository.UpdateAsync(task);
                    return task.Id;
                }
            }

            var newTask = _mapper.Map<ToDoTask>(request.TaskDto);
            await _repository.AddAsync(newTask);
            return newTask.Id;
        }
    }
}