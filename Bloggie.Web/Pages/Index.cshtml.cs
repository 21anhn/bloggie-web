using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository _repository;
        public List<BlogPost> BlogPosts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IActionResult> OnGet()
        {
            BlogPosts = (await _repository.GetAllAsync()).ToList();
            return Page();
        }
    }
}
