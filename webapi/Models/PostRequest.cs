namespace webapi.Models
{
    public class PostRequest
    {
        public string? Title { get; set; }
        public IFormFile? Content { get; set; }
    }
}
