using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class AddBlogPost
    {
        [Required]
        public string? Heading { get; set; }
        [Required]
        public string? PageTitle { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? ShortDescription { get; set; }
        [Required]
        public string? FeaturedImageUrl { get; set; }
        public string? UrlHandle { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? Visible { get; set; }
    }
}
