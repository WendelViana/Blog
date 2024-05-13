using Blog.Entities;
using Blog.Interfaces.Repository;
using Blog.Interfaces.Services;
using Blog.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Services
{
    public class PostServices : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostServices> _logger;
        private readonly IHubContext<HubNotification> _hubNotification;
        public PostServices(
            IPostRepository postRepository, 
            ILogger<PostServices> logger,
            IHubContext<HubNotification> hubNotification)    
        {
            _postRepository = postRepository;
            _logger = logger;
            _hubNotification = hubNotification;
        }

        public bool Add(PostEntity post)
        {
            
            bool result = false;

            if(!post.Validate())
            {
                _logger.LogWarning("post is not valid");
                return result;
            }
            post.CreatedAt = DateTime.Now;

            result = _postRepository.Add(post);

            string message = $"New post created: {post.Title}";
            _hubNotification.Clients.All.SendAsync("ReceiveMessage", message);

            return result;
        }

        public async Task SendNotificationAsync(string message)
        {
            await _hubNotification.Clients.All.SendAsync("SendMessage", message);
        }

        public bool Delete(int id)
        {
            return _postRepository.Delete(id);
        }

        public PostEntity? GetPost(int id)
        {
            return _postRepository.GetPost(id);
        }

        public List<PostEntity>? GetPosts()
        {
            return _postRepository.GetPosts();
        }

        public bool Update(PostEntity post)
        {
            if(!post.Validate())
            {
                return false;
            }

            var postDb = _postRepository.GetPost(post.Id);
            if(postDb == null)
            {
                _logger.LogWarning("post not found");
                return false;
            }

            postDb.SetUpdate(post);

            return _postRepository.Update(post);
        }
    }
}
