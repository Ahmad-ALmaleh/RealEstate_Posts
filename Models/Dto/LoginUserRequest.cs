using System.ComponentModel.DataAnnotations;

namespace test.Models.Dto
{
    public class LoginUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
