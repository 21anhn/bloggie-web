using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            _blogPostLikeRepository = blogPostLikeRepository;
        }

        [Route("{blogPostId:int}/totalLikes")]
        [HttpGet]
        public async Task<IActionResult> GetTotalLikes([FromRoute] int blogPostId)
        {
            var likes = await _blogPostLikeRepository.GetTotalLikesForBlog(blogPostId);
            return Ok(likes);
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBlogPostLikeRequest addBlogPostLikeRequest)
        {
            await _blogPostLikeRepository.AddLikeForBlog(addBlogPostLikeRequest.BlogPostId, addBlogPostLikeRequest.UserId);
            return Ok();
        }

        //[Route("Delete")]
        //[HttpDelete]
        //public async Task<IActionResult> 
    }
}
