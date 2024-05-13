using Blog.Entities;
using Blog.Interfaces.Repository;
using Blog.Interfaces.Services;
using System.Text;

namespace Blog.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;
        public UserService(
            IUserRepository userRepository,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;           
            _logger = logger;
        }
      
        private string ToBase64String(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        public bool Add(UserEntity user)
        {
            if (!user.Validate())
            {
                _logger.LogWarning("Invalid Data...");
                return false;
            }

            //Usei base64 devido ao tempo.Apenas para nao gravar a senha no banco...
            _logger.LogInformation("Converting to base64...");
            user.Password = ToBase64String(user.Password);

            _logger.LogInformation("Adding user");           
            return _userRepository.AddUser(user);
        }

        public bool Delete(int id)
        {
            _logger.LogInformation("Deleting user");
            return _userRepository.DeleteUser(id);
        }

        public UserEntity? GetUser(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public UserEntity? GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public List<UserEntity>? GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public UserEntity? Login(string login, string password)
        {
            return _userRepository.Login(login, ToBase64String(password));
        }

        public bool Update(UserEntity user)
        {
            if (!user.Validate())
            {
                _logger.LogWarning("Invalid Data...");
                return false;
            }

            var userDb = _userRepository.GetUserById(user.Id);
            if (userDb == null)
            {
                _logger.LogWarning("User not found...");
                return false;
            }
            
            userDb.SetUpdate(user);
            userDb.Password = ToBase64String(user.Password);

            return _userRepository.UpdateUser(user);
        }
    }
}
