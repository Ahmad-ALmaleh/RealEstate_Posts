using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Photo
    {

        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; }

        // Navigation property
        public Post Post { get; set; }



        //[Key]
        //public int Id { get; set; }
        //public string Url { get; set; }

        //// Foreign key and navigation property to Post
        //public int PostId { get; set; }
        //public Post Post { get; set; }
    }
}
