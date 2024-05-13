using Blog.Entities;

namespace Blog.Interfaces.Services
{
    public interface IUserService
    {
        bool Add(UserEntity UserEntity);
        UserEntity? GetUser(int id);
        List<UserEntity>? GetUsers();
        UserEntity? GetUserByUsername(string username);
        bool Delete(int id);
        bool Update(UserEntity UserEntity);
        UserEntity? Login(string login, string password);
    }
}
