using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class SavedPost
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public Post Post { get; set; }
        public AppUser User { get; set; }





        //public int Id { get; set; }  // New primary key

        //public int PostId { get; set; }
        //public Post Post { get; set; }

        //public string UserId { get; set; }
        //public AppUser User { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
