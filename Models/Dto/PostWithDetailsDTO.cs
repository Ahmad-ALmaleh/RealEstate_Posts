namespace test.Models.Dto
{
    public class PostWithDetailsDTO
    {
        // Post properties
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

        // PostDetails properties
        public string Description { get; set; }
        public string Utilities { get; set; }
        public string Pet { get; set; }
        public string Income { get; set; }
        public int Size { get; set; }
        public int School { get; set; }
        public int Bus { get; set; }
        public int Restaurant { get; set; }
    }
}
