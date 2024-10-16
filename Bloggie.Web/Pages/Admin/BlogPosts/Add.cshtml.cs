using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost? AddBlogPost { get; set; } //ViewModel - get data from view
        private readonly IBlogPostRepository _blogPostRepository;
        [BindProperty]
        public IFormFile FeaturedImage { get; set; }
        [BindProperty]
        public string Tags { get; set; }
        
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
                Visible = AddBlogPost.Visible,
                Tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x }))
            };

            await _blogPostRepository.AddAsync(blogPost);

            var notification = new Notification
            {
                Message = "New blog created!",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(notification);
            return RedirectToPage("/admin/blogposts/list");
        }
    }
}
