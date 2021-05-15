using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Todo.Core.Entities
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; }
        [JsonIgnore]
        public bool Completed { get; set; } = false;

        public void MarkAsComplete()
        {
            Completed = true;
        }
    }
}
