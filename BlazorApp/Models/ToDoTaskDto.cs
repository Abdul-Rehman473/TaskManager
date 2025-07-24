using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class ToDoTaskDto
    {

        public int? Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}