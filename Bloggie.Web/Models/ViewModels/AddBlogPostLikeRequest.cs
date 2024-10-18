namespace Bloggie.Web.Models.ViewModels
{
    public class AddBlogPostLikeRequest
    {
        public int BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
