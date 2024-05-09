using Blog.Entities;

namespace Blog.Interfaces.Repository
{
    public interface IUserRepository
    {
        bool AddUser(UserEntity user);
        UserEntity GetUserById(int id);
        List<UserEntity> GetUsers();
        UserEntity GetUserByUsername(string username);
        bool DeleteUser(int id);
        bool UpdateUser(UserEntity user);
    }
}
