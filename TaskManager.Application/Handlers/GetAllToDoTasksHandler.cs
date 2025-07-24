using AutoMapper;
using MediatR;
using TaskManager.Application.DTOs;
using TaskManager.Application.Queries;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers
{
    public class GetAllToDoTasksHandler : IRequestHandler<GetAllToDoTasksQuery, IEnumerable<ToDoTaskDto>>
    {
        private readonly IToDoTaskRepository _repository;
        private readonly IMapper _mapper;

        public GetAllToDoTasksHandler(IToDoTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToDoTaskDto>> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToDoTaskDto>>(tasks);
        }
    }
}
