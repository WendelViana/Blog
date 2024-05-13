using Blog.Entities;
using Blog.Infraestructure.Context;
using Blog.Interfaces.Repository;

namespace Blog.Infraestructure.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public bool Add(PostEntity post)
        {
           _context.Posts.Add(post);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id.Equals(id));
            if (post == null)
                return false;

            _context.Posts.Remove(post);
            return _context.SaveChanges() > 0;           
        }

        public PostEntity? GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<PostEntity>? GetPosts()
        {
            return _context.Posts.ToList();            
        }

        public bool Update(PostEntity post)
        {
            _context.Posts.Update(post);
            return _context.SaveChanges() > 0;
        }
    }
}
