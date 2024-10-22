using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public BlogPost BlogPost { get; set; }
        public int TotalLikes { get; set; } = 0; //Defaut value
        public bool IsLiked { get; set; } = false; //Suppose the user has not clicked the like button
        [BindProperty]
        public int BlogPostId { get; set; }
        [BindProperty]
        public string Description { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository
                            ,IBlogPostLikeRepository blogPostLikeRepository
                            ,IBlogPostCommentRepository blogPostCommentRepository
                            ,SignInManager<IdentityUser> signInManager
                            ,UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _blogPostLikeRepository = blogPostLikeRepository;
            _blogPostCommentRepository = blogPostCommentRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await _blogPostRepository.GetAsync(urlHandle);
            BlogPostId = BlogPost.Id;
            //Check user login or not
            if (_signInManager.IsSignedIn(User))
            {
                //Check user has clicked the like button
                var like = await _blogPostLikeRepository.GetLikeByBlogPostIdAndUserId(BlogPost.Id, Guid.Parse(_userManager?.GetUserId(User)));
                IsLiked = like != null;             
            }
            //Get total likes
            TotalLikes = await _blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostComment(string urlHandle)
        {
            //Check user login or not
            if(_signInManager.IsSignedIn(User))
            {
                var blogpostcomment = new BlogPostComment
                {
                    UserId = Guid.Parse(_userManager.GetUserId(User)),
                    BlogPostId = BlogPostId,
                    Description = Description,
                    DateAdded = DateTime.Now,
                };
                await _blogPostCommentRepository.AddCommentForBlog(blogpostcomment);
            }

            return RedirectToPage("/blog/details", new { urlHandle = urlHandle });
        }
    }
}
