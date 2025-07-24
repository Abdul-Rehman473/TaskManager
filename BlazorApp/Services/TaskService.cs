//using BlazorApp.Models;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;

//namespace BlazorApp.Services
//{
//    public class TaskService
//    {
//        private readonly HttpClient _http;

//        public TaskService(HttpClient http)
//        {
//            _http = http;
//        }

//        public async Task<List<ToDoTaskDto>> GetTasksAsync()
//        {
//            return await _http.GetFromJsonAsync<List<ToDoTaskDto>>("api/ToDoTask");
//        }

//        public async Task CreateTaskAsync(CreateToDoTaskDto task)
//        {
//            await _http.PostAsJsonAsync("api/ToDoTask", task);
//        }

//        public async Task UpdateTaskAsync(ToDoTaskDto task)
//        {
//            await _http.PutAsJsonAsync($"api/ToDoTask/{task.Id}", task);
//        }

//        public async Task DeleteTaskAsync(int id)
//        {
//            await _http.DeleteAsync($"api/ToDoTask/{id}");
//        }
//    }
//}

using BlazorApp.Models;
using System;
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
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<List<ToDoTaskDto>> GetTasksAsync()
        {
            try
            {
                var response = await _http.GetAsync("api/ToDoTask");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<ToDoTaskDto>>() ?? new List<ToDoTaskDto>();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to retrieve tasks. Please try again later.", ex);
            }
        }

        public async Task UpsertTaskAsync(ToDoTaskDto task)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/ToDoTask", task);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to save task. Please check your input and try again.", ex);
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/ToDoTask/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to delete task. Please try again.", ex);
            }
        }
    }
}