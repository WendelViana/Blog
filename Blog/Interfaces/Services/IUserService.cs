using Blog.Dtos;

namespace Blog.Interfaces.Services
{
    public interface IUserService
    {
        bool Add(UserDto userDto);
        UserDto GetUser(int id);
        List<UserDto> GetUsers();   
        UserDto GetUserByUsername(string username);
        bool Delete(int id);
        bool Update(UserDto userDto);
        UserDto Login(string login, string password);
    }
}
