using Blog.Dtos;
using Blog.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostsController> _logger;
        public PostsController(
            IPostService postService,
            ILogger<PostsController> logger)
        {
            _postService = postService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetPosts()
        {
            try
            {
                var posts = _postService.GetPosts();
                if (posts.Any())
                    return Ok(posts);

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get posts.");
                return StatusCode(500, "Oooops");
            }            
        }

        [HttpPost]
        public IActionResult CreatePost(PostDto post)
        {
            try
            {
                var newPost = _postService.Add(post);
                if (!newPost)
                {
                    return BadRequest("Failed to create post.");
                }

                return Ok(newPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create a new post.");
                return StatusCode(500, "Oooops");
            }
           
        }
    }
}
