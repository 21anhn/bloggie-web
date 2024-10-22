using Bloggie.Web.Models.Responses;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BlogPostCommentController : Controller
    {
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogPostCommentController(IBlogPostCommentRepository blogPostCommentRepository, UserManager<IdentityUser> userManager)
        {
            _blogPostCommentRepository = blogPostCommentRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommentsByBlogPostId([FromQuery] int blogPostId)
        {
            var comments = await _blogPostCommentRepository.GetCommentsByBlogPostIdAsync(blogPostId);
            if (comments == null)
            {
                return NotFound();  
            }

            var response = new List<CommentResponse>();

            foreach (var comment in comments)
            {
                var commentResponse = new CommentResponse
                {
                    Id = comment.Id,
                    Description = comment.Description,
                    DateAdded = comment.DateAdded.ToString("MMM dd", System.Globalization.CultureInfo.InvariantCulture),
                    UserName = (await _userManager.FindByIdAsync(comment.UserId.ToString())).UserName
                };
                response.Add(commentResponse);
            }
            return Ok(response);
        }
    }
}
