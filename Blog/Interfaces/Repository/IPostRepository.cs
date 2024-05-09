using Blog.Dtos;
using Blog.Entities;

namespace Blog.Interfaces.Repository
{
    public interface IPostRepository
    {
        bool Add(PostEntity post);
        PostDto GetPost(int id);
        List<PostDto> GetPosts();
        bool Delete(int id);
        bool Update(PostEntity post);
    }
}
