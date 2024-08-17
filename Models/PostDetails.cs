using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class PostDetails
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Utilities { get; set; }
        public string Pet { get; set; }
        public string Income { get; set; }
        public int Size { get; set; }
        public int School { get; set; }
        public int Bus { get; set; }
        public int Restaurant { get; set; }
        public int PostId { get; set; }

        // Navigation property
        public Post Post { get; set; }







        //[Key]
        //public int Id { get; set; }

        //public string Description { get; set; }
        //public string Utilities { get; set; }
        //public string Pet { get; set; }
        //public string Income { get; set; }
        //public int Size { get; set; }
        //public int School { get; set; }
        //public int Bus { get; set; }
        //public int Restaurant { get; set; }

        //// Foreign key and navigation property to Post
        //public int PostId { get; set; }
        //public Post Post { get; set; }
    }
}
