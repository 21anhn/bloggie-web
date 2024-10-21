using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories.Interfaces
{
    public interface IBlogPostCommentRepository
    {
        Task<IEnumerable<BlogPostComment>> GetCommentsByBlogPostIdAsync(int blogPostId);
        Task AddCommentForBlog(BlogPostComment comment);
    }
}
