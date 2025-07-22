using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces
{
    public interface IToDoTaskRepository
    {
        Task<IEnumerable<ToDoTask>> GetAllAsync();
        Task<ToDoTask> GetbyIdAsync(int id);
        Task AddAsync(ToDoTask task);
        Task UpdateAsync(ToDoTask task);
        Task DeleteAsync(int id);
    }
}
