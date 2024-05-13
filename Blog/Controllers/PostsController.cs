using Blog.Entities;
using Blog.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
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

        [HttpGet("list")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
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

        [HttpPost("sendMessage")]
        public IActionResult Teste([FromBody] string teste)
        {
            _postService.SendNotificationAsync(teste);
            return Ok();
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreatePost([FromBody]PostEntity post)
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

        [HttpPut("update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult UpdatePost([FromBody]PostEntity post)
        {
            try
            {
                var updatedPost = _postService.Update(post);
                if (!updatedPost)
                {
                    return BadRequest("Failed to update post.");
                }

                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update post.");
                return StatusCode(500, "Oooops");
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult DeletePost(int id)
        {
            try
            {
                var deleted = _postService.Delete(id);
                if (!deleted)
                {
                    return BadRequest("Failed to delete post.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete post.");
                return StatusCode(500, "Oooops");
            }
        }
    }
}
