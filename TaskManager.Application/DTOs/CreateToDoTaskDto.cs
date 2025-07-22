using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.DTOs
{
    public class CreateToDoTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
