using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Authorization.auth
{
    public record class UserDto
    {
        [Required]
        [NotNull]
        public string Login { get; set; } = string.Empty;
        [Required]
        [NotNull]
        public string Password { get; set; } = string.Empty ;
    }
    public class UserModel
    {
        public int Id { get; set; }
        public UserModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        [Required]
        [NotNull]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [NotNull]
        public string Password { get; set; } = string.Empty;
        [Required]
        [NotNull]
        public string Email { get; set; } = string.Empty;
        [Required]
        [NotNull]
        public string Login { get; set; } = string.Empty;
        [Required]
        [NotNull]
        [StringLength(11)]
        public string mobile { get; set; } = string.Empty;
    }

}