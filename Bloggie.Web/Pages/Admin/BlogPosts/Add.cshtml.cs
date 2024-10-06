using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost? AddBlogPost { get; set; } //ViewModel - get data from view
        private readonly BloggieDbContext _context;

        public AddModel(BloggieDbContext context)
        {
            _context = context;
        }
        public void OnPost() //Create post
        {
            var blogPost = new BlogPost()
            {
                Heading = AddBlogPost.Heading,
                PageTitle = AddBlogPost.PageTitle,
                Content = AddBlogPost.Content,
                ShortDescription = AddBlogPost.ShortDescription,
                FeaturedImageUrl = AddBlogPost.FeaturedImageUrl,
                UrlHandle = AddBlogPost.UrlHandle,
                Author = AddBlogPost.Author,
                PublishedDate = AddBlogPost.PublishedDate,
                Visible = AddBlogPost.Visible
            };
            _context.BlogPosts.Add(blogPost);
            _context.SaveChanges();
        }
    }
}
