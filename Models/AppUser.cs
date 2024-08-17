using Microsoft.AspNetCore.Identity;

namespace test.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<SavedPost> SavedPosts { get; set; }
    }
}
