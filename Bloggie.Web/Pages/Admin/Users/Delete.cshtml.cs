using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public DeleteModel(IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet(Guid userId)
        {
            var userIdentity = await _userManager.FindByIdAsync(userId.ToString());
            if (userIdentity == null)
            {
                return Page();
            }
            await _userRepository.DeleteUserAsync(userIdentity);
            return RedirectToPage("/admin/users/index");
        }
    }
}
