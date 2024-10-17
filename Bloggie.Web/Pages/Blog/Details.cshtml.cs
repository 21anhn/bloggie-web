using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; } = 0; //Defaut value

        public DetailsModel(IBlogPostRepository blogPostRepository, IBlogPostLikeRepository blogPostLikeRepository)
        {
            _blogPostRepository = blogPostRepository;
            _blogPostLikeRepository = blogPostLikeRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await _blogPostRepository.GetAsync(urlHandle);
            //Get total likes
            TotalLikes = await _blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            
            return Page();
        }
    }
}
