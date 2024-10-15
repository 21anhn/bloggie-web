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
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost()
        {
            var signInResult = await _signInManager.PasswordSignInAsync(LoginViewModel.Username, LoginViewModel.Password, false, false);
            
            if(signInResult.Succeeded)
            {
                return RedirectToPage("Index");
            }

            ViewData["Notification"] = new Notification
            {
                Message = "Unable to login!",
                Type = Enums.NotificationType.Error
            };
            return Page();
        }
    }
}
