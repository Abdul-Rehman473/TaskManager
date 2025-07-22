using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;

namespace TaskManager.Application.Queries
{
    public class GetToDoTaskByIdQuery : IRequest<ToDoTaskDto>
    {
        public int Id { get; set; }
    }
}
