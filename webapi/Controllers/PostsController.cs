using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Providers;
using webapi.Models;
using System.Runtime.Intrinsics.Arm;
using FirebaseAdmin.Messaging;

public class ResPos
{
    public string Title { get; set; }
    public string Content { get; set; }
};

namespace webapi.Controllers
{
    /*[Authorize]*/
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly FirestoreProvider _firestoreProvider = new FirestoreProvider();

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResPos>>> GetPosts()
        {
            List<ResPos> posts = new List<ResPos>();

            List<Post> data = await _firestoreProvider.GetAllPost();
            foreach (Post dbpost in data)
            {
                ResPos post = new ResPos();
                post.Title = dbpost.PostTitle ?? "no titile";

                post.Content =
                    "https://firebasestorage.googleapis.com/v0/b/asp-net-socialmedia.appspot.com/o/"
                    + dbpost.Id.ToString()
                    + "?alt=media";

                posts.Add(post);
            }
            return Ok(posts);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(string id)
        {
            return Ok(_firestoreProvider.GetPostData(id));
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(Post post)
        {
            _firestoreProvider.UpdatePost(post);
            return Ok();
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Post>> PostPostAsync([FromForm] PostRequest postRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToArray()
                        .ToString()
                );
            }

            var post = new Post { PostTitle = postRequest.Title, Username = "username" };

            var stream = postRequest.Content.OpenReadStream();

            var task = new FirebaseStorage("asp-net-socialmedia.appspot.com")
                .Child(post.Id.ToString())
                .PutAsync(stream);
            task.Progress.ProgressChanged += (s, e) =>
                Console.WriteLine($"Progress: {e.Percentage} %");
            var downloadUrl = await task;

            _firestoreProvider.AddPost(post);

            return Ok();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            _firestoreProvider.DeletePost(id);

            return NoContent();
        }
    }
}
