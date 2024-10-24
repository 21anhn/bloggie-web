﻿using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAllAsync();
        Task AddUserAsync(IdentityUser user);
        Task DeleteUserAsync(IdentityUser user);
    }
}
