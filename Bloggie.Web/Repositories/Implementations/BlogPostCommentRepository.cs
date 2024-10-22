using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories.Implementations
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BloggieDbContext _context;

        public BlogPostCommentRepository(BloggieDbContext context)
        {
            _context = context;
        }

        public async Task AddCommentForBlog(BlogPostComment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogPostIdAsync(int blogPostId)
        {
            var comments = await _context.Comments.Where(c => c.BlogPostId == blogPostId).ToListAsync();
            return comments;
        }
    }
}
