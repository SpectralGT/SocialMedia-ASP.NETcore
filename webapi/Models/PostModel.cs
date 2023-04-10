using Microsoft.AspNetCore.SignalR;

namespace webapi.Models
{
    public class PostModel
    {
        public Guid PostId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
