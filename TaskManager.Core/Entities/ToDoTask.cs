using System;

namespace TaskManager.Core.Entities
{
    public class ToDoTask
    {
        
        public int Id { get; set; }

       
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty or whitespace.");
                if (value.Trim().Length > 100)
                    throw new ArgumentException("Title cannot exceed 100 characters.");
                _title = value.Trim();
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            private set => _description = value?.Trim() ?? string.Empty;
        }

        public bool IsCompleted { get; private set; }


        public DateTime CreatedAt { get; private set; }

        public DateTime? CompletedAt { get; private set; }

        
        public ToDoTask() { }

        public ToDoTask(string title, string description, DateTime? createdAt = null, bool isCompleted = false, DateTime? completedAt = null)
        {
            Title = title;
            Description = description;
            CreatedAt = createdAt ?? DateTime.UtcNow;
            if (isCompleted && !completedAt.HasValue)
                throw new ArgumentException("CompletedAt must be provided if task is marked as completed.");
            if (completedAt.HasValue && completedAt > DateTime.UtcNow)
                throw new ArgumentException("CompletedAt cannot be in the future.");
            CompletedAt = completedAt;
            IsCompleted = isCompleted;
        }

       
        public void SetTitle(string title) => Title = title;
        public void SetDescription(string description) => Description = description;
        public void SetCreatedAt(DateTime createdAt) => CreatedAt = createdAt > DateTime.UtcNow ? throw new ArgumentException("CreatedAt cannot be in the future.") : createdAt;
        public void SetCompletedAt(DateTime completedAt) => CompletedAt = completedAt > DateTime.UtcNow ? throw new ArgumentException("CompletedAt cannot be in the future.") : completedAt;

        public void MarkComplete()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Task is already completed.");
            IsCompleted = true;
            CompletedAt = DateTime.UtcNow;
        }
        public void MarkIncomplete()
        {
            if (!IsCompleted)
                throw new InvalidOperationException("Task is not yet completed.");
            IsCompleted = false;
            CompletedAt = null;
        }
    }
}