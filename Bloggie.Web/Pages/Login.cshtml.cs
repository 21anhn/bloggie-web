using Bloggie.Web.Data;
using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginViewModel { get; set; }
        private readonly UserManager<IdentityUser> _userManager;

        public LoginModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.FindByNameAsync(LoginViewModel.Username);
            if (user == null)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Username does not exist!",
                    Type = Enums.NotificationType.Error
                };
                return Page();
            }

            var isSuccess = new PasswordHasher<IdentityUser>().VerifyHashedPassword(user, user.PasswordHash, LoginViewModel.Password);

            if(isSuccess == PasswordVerificationResult.Failed)
            {
                ViewData["Notification"] = new Notification
                {
                    Message = "Passsword is incorrect!",
                    Type = Enums.NotificationType.Error
                };
                return Page();
            }

            ViewData["Notification"] = new Notification
            {
                Message = "Login successfully!",
                Type = Enums.NotificationType.Success
            };
            return RedirectToPage("Index");
        }
    }
}
