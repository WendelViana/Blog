using Blog.Entities;
using Blog.Infraestructure.Context;
using Blog.Interfaces.Repository;

namespace Blog.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;                
        }
        public bool AddUser(UserEntity user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            return _context.SaveChanges() > 0;
        }

        public UserEntity? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public UserEntity? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username.Equals(username));
        }

        public List<UserEntity>? GetUsers()
        {
            return _context.Users.ToList();
        }

        public UserEntity? Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
        }

        public bool UpdateUser(UserEntity user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges() > 0;
        }
    }
}
