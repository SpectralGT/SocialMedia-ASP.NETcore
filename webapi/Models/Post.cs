using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int PostId { get; set; }
        public string? PostTitle { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
