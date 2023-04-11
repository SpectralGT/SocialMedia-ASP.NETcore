using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Post
    {
        [Key]
        [Required]
        public int PostId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
