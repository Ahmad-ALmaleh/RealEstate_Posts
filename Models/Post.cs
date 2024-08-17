using static System.Net.Mime.MediaTypeNames;

namespace test.Models
{
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public string Property { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OwnerId { get; set; }

        // Navigation properties
        public AppUser Owner { get; set; }

        public PostDetails PostDetails { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<SavedPost> SavedPosts { get; set; }







        //public int Id { get; set; }
        //public string Title { get; set; }
        //public int Price { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public int Bedroom { get; set; }
        //public int Bathroom { get; set; }
        //public double Latitude { get; set; }
        //public double Longitude { get; set; }
        //public string Type { get; set; } // Enum: "rent", "buy"
        //public string Property { get; set; } // Enum: "house", "condo", "land", "apartment"
        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;




        //// Foreign key and navigation property to AppUser (Owner)
        //public string OwnerId { get; set; }
        //public AppUser Owner { get; set; }

        //// Navigation property for PostDetails
        //public PostDetails PostDetails { get; set; }

        //// Navigation property for Images
        //public ICollection<Photo> Photos { get; set; }

        //// Navigation property for SavedPosts
        //public ICollection<SavedPost> SavedPosts { get; set; }


    }
}
