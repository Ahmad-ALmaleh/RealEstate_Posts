using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;
using test.Models.Dto;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedPostsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SavedPostsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/SavedPosts
        [HttpPost]
        public async Task<IActionResult> CreateSavedPost([FromBody] SavePostDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data.");
            }

            var savedPost = new SavedPost
            {
                UserId = dto.UserId,
                PostId = dto.PostId,
                CreatedAt = DateTime.UtcNow
            };

            _context.SavedPosts.Add(savedPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSavedPost), new { dto.UserId, dto.PostId }, savedPost);
        }

        // GET: api/SavedPosts/5
        [HttpGet("{userId}/{postId}")]
        public async Task<ActionResult<SavedPost>> GetSavedPost(string userId, int postId)
        {
            var savedPost = await _context.SavedPosts
                .Include(sp => sp.Post)
                .Include(sp => sp.User)
                .FirstOrDefaultAsync(sp => sp.UserId == userId && sp.PostId == postId);

            if (savedPost == null)
            {
                return NotFound();
            }

            return Ok(savedPost);
        }

        // DELETE: api/SavedPosts/5
        [HttpDelete("{userId}/{postId}")]
        public async Task<IActionResult> DeleteSavedPost(int userId, int postId)
        {
            var savedPost = await _context.SavedPosts
                .FirstOrDefaultAsync(sp => sp.UserId == userId && sp.PostId == postId);

            if (savedPost == null)
            {
                return NotFound();
            }

            _context.SavedPosts.Remove(savedPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
