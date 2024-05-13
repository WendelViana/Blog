using Blog.Entities;

namespace Blog.Interfaces.Repository
{
    public interface IUserRepository
    {
        bool AddUser(UserEntity user);
        UserEntity? GetUserById(int id);
        List<UserEntity>? GetUsers();
        UserEntity? GetUserByUsername(string username);
        UserEntity? Login(string username, string password);
        bool DeleteUser(int id);
        bool UpdateUser(UserEntity user);
    }
}
