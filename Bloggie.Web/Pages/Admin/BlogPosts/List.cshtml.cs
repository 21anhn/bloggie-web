using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
        private readonly BloggieDbContext _context;
        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(BloggieDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            BlogPosts = _context.BlogPosts.ToList();
        }
    }
}
