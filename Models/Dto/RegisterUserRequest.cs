using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models.Dto
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // Optional image, provided by [FromForm]
        public IFormFile? Image { get; set; }
    }
}
