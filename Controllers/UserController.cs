using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using susFaceGen.Areas.Identity.Data;

namespace susFaceGen.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<susFaceGenUser> _userManager;

        public UserController(UserManager<susFaceGenUser> userManager)
        {
            _userManager = userManager;
        }

        private async Task<susFaceGenUser> LoadUserAsync(string? id)
        {
            susFaceGenUser user = null;
            if (id is null)
            {
                user = await _userManager.GetUserAsync(User);
            }
            else
            {
                user = await _userManager.FindByIdAsync(id);
            }
            return user;
        }

        public async Task<IActionResult> DisableOrEnable(string? id)
        {
            var user = await LoadUserAsync(id);
            if (user == null)
            {
                return RedirectToAction("UserList", "Admin", "");
            }
            if(user.NormalizedEmail == "DEV@SUSFACEGEN.LK")
            {
                TempData["StatusMessage"] = $"Error: Unable to disable global admin user.";
                return RedirectToAction("UserList", "Admin", "");
            }

            user.IsEnabled = user.IsEnabled ? false : true;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList", "Admin", "");
            }
            else
            {
                TempData["StatusMessage"] = $"Error: Unable to disable user {user.UserName}.";
                return RedirectToAction("UserList", "Admin", "");
            }
        }
    }
}
