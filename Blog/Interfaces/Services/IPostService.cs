using Blog.Dtos;

namespace Blog.Interfaces.Services
{
    public interface IPostService
    {
        bool Add(PostDto postDto);
        PostDto GetPost(int id);
        List<PostDto> GetPosts();
        bool Delete(int id);
        bool Update(PostDto postDto);        
    }
}
