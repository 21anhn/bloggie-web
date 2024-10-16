namespace Bloggie.Web.Models.Domain
{
    public class BlogPostLike
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
