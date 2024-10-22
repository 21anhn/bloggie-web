﻿using Bloggie.Web.Data;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }
        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await _authDbContext.Users.ToListAsync();
            var superAdminUsers = await _authDbContext.Users.FirstOrDefaultAsync(s => s.Email == "superadmin@bloggie.com");

            if (superAdminUsers != null)
            {
                users.Remove(superAdminUsers);
            }

            return users;
        }
    }
}
