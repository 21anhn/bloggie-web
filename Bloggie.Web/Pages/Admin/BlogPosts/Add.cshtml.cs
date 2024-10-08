using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost? AddBlogPost { get; set; } //ViewModel - get data from view
        private readonly IBlogPostRepository _blogPostRepository;

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public async Task<IActionResult> OnPost() //Create post
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
            await _blogPostRepository.AddAsync(blogPost);
            return RedirectToPage("/admin/blogposts/list");
        }
    }
}
