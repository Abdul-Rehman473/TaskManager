﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Commands
{
    public class DeleteToDoTaskCommand : IRequest
    {
        public int Id { get; set; }
    }
}
