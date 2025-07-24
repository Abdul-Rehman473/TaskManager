using BlazorApp.Models;
using System.Net.Http.Json;

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