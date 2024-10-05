namespace Bloggie.Web.Models.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogPostId { get; set; }
    }
}
