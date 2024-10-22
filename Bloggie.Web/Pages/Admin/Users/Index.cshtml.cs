using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        public List<UserViewModel> Users { get; set; }

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            var users = await _userRepository.GetAll();
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
    }
}
