using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories.Interfaces;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        public List<UserViewModel> Users { get; set; }
        [BindProperty]
        public UserViewModel UserViewModel { get; set; }

        public IndexModel(IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            var users = await _userRepository.GetAllAsync();
            Users = new List<UserViewModel>();

            foreach (var user in users)
            {
                Users.Add(new Models.ViewModels.UserViewModel
                {
                    Id = Guid.Parse(user.Id),
                    UserName = user?.UserName,
                    Email = user?.Email
                });
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = new IdentityUser
            {
                UserName = UserViewModel.UserName,
                Email = UserViewModel.Email,
                NormalizedUserName = UserViewModel.UserName.ToUpper(),
                NormalizedEmail = UserViewModel.Email.ToUpper(),
            };

            var passwordHash = new PasswordHasher<IdentityUser>().HashPassword(user, UserViewModel.Password);
            user.PasswordHash = passwordHash;

            await _userRepository.AddUserAsync(user);
            var identityResult = await _userManager.AddToRolesAsync(user, UserViewModel.Roles);

            if(identityResult.Succeeded)
            {
                //ViewData["Notification"] = new Notification
                //{
                //    Type = Enums.NotificationType.Success,
                //    Message = "User registered successfully!"
                //};
                return RedirectToPage("/admin/users/index");
            }

            ViewData["Notification"] = new Notification
            {
                Type = Enums.NotificationType.Error,
                Message = "Something went wrong!"
            };
            return Page();
        }
    }
}
    