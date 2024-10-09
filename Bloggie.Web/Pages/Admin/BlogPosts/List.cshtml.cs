using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        public async Task OnGet()
        {
            var notificationJson = TempData["Notification"] as string;
            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }
               
            BlogPosts = await _context.BlogPosts.ToListAsync();
        }
    }
}
