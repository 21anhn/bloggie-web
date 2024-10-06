using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly BloggieDbContext _context;
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public EditModel(BloggieDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            BlogPost = _context.BlogPosts.Find(id);
        }
    }
}
