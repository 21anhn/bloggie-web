using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories.Interfaces
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(int blogId);
        Task AddLikeForBlog(int blogPostId, Guid userId);
        Task<BlogPostLike> GetLikeByBlogPostIdAndUserId(int blogPostId, Guid userId);
    }
}
