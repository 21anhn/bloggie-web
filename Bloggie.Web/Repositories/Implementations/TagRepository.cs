using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext _context;

        public TagRepository(BloggieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var tags = await _context.Tags.ToListAsync();

            return tags.DistinctBy(tags => tags.Name.ToLower());
        }
    }
}
