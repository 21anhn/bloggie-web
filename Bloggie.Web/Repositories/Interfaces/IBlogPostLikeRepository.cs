using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories.Interfaces
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlogAsync(int blogId);
        Task AddLikeForBlogAsync(int blogPostId, Guid userId);
        Task<BlogPostLike> GetLikeByBlogPostIdAndUserIdAsync(int blogPostId, Guid userId);
    }
}
