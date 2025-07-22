using BlazorApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class TaskService
    {
        private readonly HttpClient _http;

        public TaskService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ToDoTaskDto>> GetTasksAsync()
        {
            return await _http.GetFromJsonAsync<List<ToDoTaskDto>>("api/ToDoTask");
        }

        public async Task CreateTaskAsync(CreateToDoTaskDto task)
        {
            await _http.PostAsJsonAsync("api/ToDoTask", task);
        }

        public async Task UpdateTaskAsync(ToDoTaskDto task)
        {
            await _http.PutAsJsonAsync($"api/ToDoTask/{task.Id}", task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _http.DeleteAsync($"api/ToDoTask/{id}");
        }
    }
}