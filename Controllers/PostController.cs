using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using test.Data;
using test.Models;
using test.Models.Dto;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts
                                 .Include(p => p.Photos)
                                 .Include(p => p.PostDetails)
                                 .Include(p => p.Owner)
                                 .ToListAsync();
        }

        // GET: api/Post/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts
                                     .Include(p => p.Photos)
                                     .Include(p => p.PostDetails)
                                     .Include(p => p.Owner)
                                     .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Post
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Post>> CreatePostWithDetails(PostWithDetailsDTO dto)
        {
            // Extract the user ID from the token
            var ownerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Step 1: Create the Post entity
            var post = new Post
            {
                Title = dto.Title,
                Price = dto.Price,
                Address = dto.Address,
                City = dto.City,
                Bedroom = dto.Bedroom,
                Bathroom = dto.Bathroom,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Type = dto.Type,
                Property = dto.Property,
                OwnerId = ownerId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync(); // Save to get the Post Id

            // Step 2: Create the PostDetails entity
            var postDetails = new PostDetails
            {
                Description = dto.Description,
                Utilities = dto.Utilities,
                Pet = dto.Pet,
                Income = dto.Income,
                Size = dto.Size,
                School = dto.School,
                Bus = dto.Bus,
                Restaurant = dto.Restaurant,
                PostId = post.Id // Link the PostDetails with the newly created Post
            };

            _context.PostDetails.Add(postDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        // PUT: api/Post/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Post/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
