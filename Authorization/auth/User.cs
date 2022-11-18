using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
      
        public string UserName { get; set; } = string.Empty;
        [NotMapped]
        public string Repassword { get; set; } = string.Empty;
        [NotMapped]
        public bool Policy { get; set; } 

        public string Password { get; set; } = string.Empty;
    
        public string Email { get; set; } = string.Empty;
   
        public string Login { get; set; } = string.Empty;
       
        public string mobile { get; set; } = string.Empty;
    }

}