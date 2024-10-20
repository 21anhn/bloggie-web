namespace Bloggie.Web.Models.Domain
{
    public class BlogPostComment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BlogPostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
