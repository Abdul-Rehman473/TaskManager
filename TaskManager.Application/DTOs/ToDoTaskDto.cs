//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskManager.Application.DTOs
//{
//    public class ToDoTaskDto
//    {
//        public int Id { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public bool IsCompleted { get; set; }
//        public DateTime CreatedAt { get; set; }
//        public DateTime? CompletedAt { get; set; }
//    }
//}


using System;

namespace TaskManager.Application.DTOs
{
    public class ToDoTaskDto
    {
        
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}