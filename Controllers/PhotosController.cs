using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Models.Dto;
using test.Models;
using test.Data;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly AppDbContext _context;

        public PhotosController(IWebHostEnvironment hostEnvironment, AppDbContext context)
        {
            _hostEnvironment = hostEnvironment;
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto([FromForm] PhotoUploadDto photoUploadDto)
        {
            if (photoUploadDto.File == null || photoUploadDto.File.Length == 0)
                return BadRequest("No file uploaded.");

            // تعيين المسار الكامل لتخزين الصورة
            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoUploadDto.File.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoUploadDto.File.CopyToAsync(stream);
            }

            // تخزين رابط الصورة والـ PostId في قاعدة البيانات
            var photoRecord = new Photo
            {
                Url = "/uploads/" + fileName,
                CreatedAt = DateTime.UtcNow,
                PostId = photoUploadDto.PostId
            };

            // تأكد من إضافة context المناسب للوصول لقاعدة البيانات
            _context.Photos.Add(photoRecord);
            await _context.SaveChangesAsync();

            return Ok(new { Url = photoRecord.Url });
        }
    }
}

