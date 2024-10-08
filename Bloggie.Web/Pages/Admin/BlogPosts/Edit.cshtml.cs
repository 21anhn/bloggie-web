using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(int id)
        {
            BlogPost = await _blogPostRepository.GetAsync(id);
        }

        public async Task<IActionResult> OnPostEdit()
        {
            await _blogPostRepository.UpdateAsync(BlogPost);
            return RedirectToPage("/admin/blogposts/list");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var isDeleted = await _blogPostRepository.DeleteAsync(BlogPost.Id);
            if (isDeleted) return RedirectToPage("/admin/blogposts/list");
            return Page();
        }
    }
}
