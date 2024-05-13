using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Blog.Entities
{
    public class UserEntity
    {
        [JsonIgnore]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Username { get; set; }

        [MaxLength(8)]
        [PasswordPropertyText(true)]
        public string Password { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(2)]
        public string? Ddd { get; set; }
        
        [MaxLength(20)]
        public string? Phone { get; set; }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
                return false;

            if (string.IsNullOrEmpty(Username))
                return false;

            if (string.IsNullOrEmpty(Password))
                return false;

            if (string.IsNullOrEmpty(Email))
                return false;

            return true;
        }

        public void SetUpdate(UserEntity user)
        {
            Name = user.Name;
            Username = user.Username;
            Email = user.Email;
            Ddd = user.Ddd;
            Phone = user.Phone;
        }
    }
}
