using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Data;
using TaskManager.Core.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class ToDoTaskRepository : IToDoTaskRepository
    {
        private readonly AppDbContext _context;
        public ToDoTaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
            return await _context.NewTasks.ToListAsync();
        }

        public async Task<ToDoTask> GetbyIdAsync(int id)
        {
            return await _context.NewTasks.FindAsync(id);
        }


        public async Task AddAsync(ToDoTask task)
        {
            _context.NewTasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoTask task)
        {
            _context.NewTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.NewTasks.FindAsync(id);

            if(task != null)
            {
                _context.NewTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }



    }
}
