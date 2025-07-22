using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Commands;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Handlers
{
    public class DeleteToDoTaskHandler : IRequestHandler<DeleteToDoTaskCommand>
    {
        private readonly IToDoTaskRepository _repository;

        public DeleteToDoTaskHandler(IToDoTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
