using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.BlogPosts
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost? AddBlogPost { get; set; } //ViewModel - get data from view
        public void OnPost() //Create post
        {

        }
    }
}
