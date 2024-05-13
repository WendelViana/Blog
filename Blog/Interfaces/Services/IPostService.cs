using Blog.Entities;

namespace Blog.Interfaces.Services
{
    public interface IPostService
    {
        Task SendNotificationAsync(string message);
        bool Add(PostEntity PostEntity);
        PostEntity? GetPost(int id);
        List<PostEntity>? GetPosts();
        bool Delete(int id);
        bool Update(PostEntity PostEntity);
    }
}
