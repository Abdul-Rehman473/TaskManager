using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Queries;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers
{
    public class GetToDoTaskByIdHandler : IRequestHandler<GetToDoTaskByIdQuery, ToDoTaskDto>
    {
        private readonly IToDoTaskRepository _repository;
        private readonly IMapper _mapper;

        public GetToDoTaskByIdHandler(IToDoTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ToDoTaskDto> Handle(GetToDoTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetbyIdAsync(request.Id);
            return task != null ? _mapper.Map<ToDoTaskDto>(task) : null;
        }
    }
}
