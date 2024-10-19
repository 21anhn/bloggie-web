using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(int blogId);
        Task AddLikeForBlog(int blogPostId, Guid userId);
        Task<BlogPostLike> getLikeByBlogPostIdAndUserId(int blogPostId, Guid userId);
    }
}
