using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _repository;
        public BlogPost BlogPost { get; set; }
        public DetailsModel(IBlogPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            BlogPost = await _repository.GetAsync(urlHandle);
            return Page();
        }
    }
}
