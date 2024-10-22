namespace Bloggie.Web.Models.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
