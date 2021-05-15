using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Todo.Core.Entities
{
    public class User
    {
        [JsonIgnore]
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [JsonIgnore]
        [Required]
        public string Username { get; set; }

        [JsonIgnore]
        [Required]
        public string Password { get; set; }
    }
}
