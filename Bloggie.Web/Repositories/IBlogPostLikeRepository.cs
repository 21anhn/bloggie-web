namespace Bloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(int blogId);
        Task AddLikeForBlog(int blogPostId, Guid userId);
    }
}
