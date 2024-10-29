using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories.Implementations
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext _context;

        public BlogPostLikeRepository(BloggieDbContext context)
        {
            _context = context;
        }

        public async Task AddLikeForBlogAsync(int blogPostId, Guid userId)
        {
            var like = new BlogPostLike
            {
                BlogPostId = blogPostId,
                UserId = userId,
            };

            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task<BlogPostLike> GetLikeByBlogPostIdAndUserIdAsync(int blogPostId, Guid userId)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(like => like.UserId == userId && like.BlogPostId == blogPostId);
            return like;
        }

        public async Task<int> GetTotalLikesForBlogAsync(int blogId)
        {
            return await _context.Likes.CountAsync(l => l.BlogPostId == blogId);
        }
    }
}
