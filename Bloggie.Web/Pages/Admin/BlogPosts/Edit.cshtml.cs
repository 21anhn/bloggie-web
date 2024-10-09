using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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
            try
            {

                await _blogPostRepository.UpdateAsync(BlogPost);
                ViewData["Notification"] = new Notification
                {
                    Message = "Recored updated successfully!",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Something went wrong!",
                    Type = Enums.NotificationType.Error
                };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var isDeleted = await _blogPostRepository.DeleteAsync(BlogPost.Id);
            if (isDeleted)
            {
                var notification = new Notification
                {
                    Message = "Blog was deleted successfully!",
                    Type = Enums.NotificationType.Success
                };
                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/admin/blogposts/list");
            }
            return Page();
        }
    }
}
