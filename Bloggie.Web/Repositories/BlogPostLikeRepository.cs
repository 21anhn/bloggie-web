
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext _context;

        public BlogPostLikeRepository(BloggieDbContext context)
        {
            _context = context;
        }

        public async Task AddLikeForBlog(int blogPostId, Guid userId)
        {
            var like = new BlogPostLike
            {
                BlogPostId = blogPostId,
                UserId = userId,
            };
            
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTotalLikesForBlog(int blogId)
        {
            return await _context.Likes.CountAsync(l => l.BlogPostId == blogId);
        }
    }
}
