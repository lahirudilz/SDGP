// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using susFaceGen.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace susFaceGen.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "admin")]
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<susFaceGenUser> _userManager;
        private readonly SignInManager<susFaceGenUser> _signInManager;
        private readonly ILogger<DeletePersonalData> _logger;

        public DeletePersonalDataModel(
            UserManager<susFaceGenUser> userManager,
            SignInManager<susFaceGenUser> signInManager,
            ILogger<DeletePersonalData> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public bool RequirePassword { get; set; }
        public string UserName { get; set; }
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
        public async Task<IActionResult> OnGet(string id)
        {

            var user = await LoadUserAsync(id);
            UserName = user.UserName;

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.NormalizedEmail == "DEV@SUSFACEGEN.LK")
            {
                StatusMessage = $"Error: Unable to delete Global Admin Account";
                return RedirectToAction("UserList", "Admin", "");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var devuser = await _userManager.GetUserAsync(User);
            var user = await LoadUserAsync(id);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.CheckPasswordAsync(devuser, Input.Password))
            {
                ModelState.AddModelError(string.Empty, "Incorrect password.");
                return Page();
            }
            if (user.NormalizedUserName is "DEV@SUSFACEGEN.LK")
            {
                StatusMessage = $"Error: Unable to delete Global Admin Account";
                return Page();
            }
            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            _logger.LogInformation($"User with ID '{userId}' deleted by {devuser.UserName}.");
            StatusMessage = $"User {user.Email} has deleted successfully";
            return Redirect("~/Admin/UserList");
        }
    }
}
