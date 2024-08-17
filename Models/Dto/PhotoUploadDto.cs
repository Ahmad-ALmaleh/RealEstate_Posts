namespace test.Models.Dto
{
    public class PhotoUploadDto
    {
        public IFormFile File { get; set; }
        public int PostId { get; set; }
    }
}
