
using Bloggie.Web.Data;
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


        public async Task<int> GetTotalLikesForBlog(int blogId)
        {
            return await _context.Likes.CountAsync(l => l.BlogPostId == blogId);
        }
    }
}
