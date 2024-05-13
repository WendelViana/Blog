using Blog.Entities;

namespace Blog.Interfaces.Repository
{
    public interface IPostRepository
    {
        bool Add(PostEntity post);
        PostEntity? GetPost(int id);
        List<PostEntity>? GetPosts();
        bool Delete(int id);
        bool Update(PostEntity post);
    }
}
