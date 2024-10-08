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

        public IActionResult OnPostEdit()
        {
            var existingBlogPost = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Visible = BlogPost.Visible;
            }
            _context.SaveChanges();
            return RedirectToPage("/admin/blogposts/list");
        }

        public IActionResult OnPostDelete()
        {
            var existingBlogPost = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlogPost != null)
            {
                _context.BlogPosts.Remove(existingBlogPost);
                _context.SaveChanges();
                return RedirectToPage("/admin/blogposts/list");
            }
            return Page();
        }
    }
}
