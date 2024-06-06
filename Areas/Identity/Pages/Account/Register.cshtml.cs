#nullable disable

using IdentityPasswordGenerator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using susFaceGen.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;


// Need to create Roles for assign to users... Ex L1, L2
namespace susFaceGen.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "admin")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<susFaceGenUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<susFaceGenUser> _userManager;
        private readonly IUserStore<susFaceGenUser> _userStore;
        private readonly IUserEmailStore<susFaceGenUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<susFaceGenUser> userManager,
            IUserStore<susFaceGenUser> userStore,
            SignInManager<susFaceGenUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        [BindProperty]
        public List<SelectListItem> UserRoleList { get; set; }

        public class InputModel
        {
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FName { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LName { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Job Id")]
            public string JobId { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Job Position")]
            public string JobPosition { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "User Role")]
            public string UserRole { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            List<IdentityRole> l = _roleManager.Roles.ToList();
            List<string> roles = new List<string>();
            foreach (var item in l)
            {
                roles.Add(item.Name);
            }
            UserRoleList = roles.Select(x => new SelectListItem { Text = x, Value = x }).ToList();
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.JobPosition = Input.JobPosition;
                user.FName = Input.FName;
                user.LName = Input.LName;
                user.JobId = Input.JobId;
                user.IsEnabled = false;

                var passwordGenerator = new PasswordGenerator();
                var options =  new PasswordOptions()
                {
                    RequireDigit = true,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireNonAlphanumeric = true,
                    RequireUppercase = true
                };
                var password = passwordGenerator.GeneratePassword(options);
                Console.WriteLine(password);

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, Input.UserRole);
                    if (roleResult.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        var email = "<!DOCTYPE html><html lang='en''><head><meta charset='UTF-8'>" +
                            "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
                            "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
                            "<title>Confirm Email</title>" +
                            "</head>" +
                            "<body>" +
                            "<div style='background-color: #f4f4f4; padding: 20px;'>" +
                            "<div style='background-color: #fff; border-radius: 5px; padding: 20px;'>" +
                            "<h1 style='text-align: center;'>Confirm Email</h1>" +
                            $"<p>Hello {user.FName},</p>" +
                            "<p>You recently created an account. Click the link below to confirm your email.</p>" +
                            $"<p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}' style='background-color: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>Confirm Email</a></p>" +
                            "<p>If you did not create an account, please ignore this email.</p>" +
                            "<p>Thanks,</p>" +
                            "<p>SusFaceGen</p>" +
                            "</div>" +
                            "</div>" +
                            "</body>" +
                            "</html>";

                        var passwordEmail = "<!DOCTYPE html><html lang='en''><head><meta charset='UTF-8'>" +
                           "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
                           "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
                           "<title>Confirm Email</title>" +
                           "</head>" +
                           "<body>" +
                           "<div style='background-color: #f4f4f4; padding: 20px;'>" +
                           "<div style='background-color: #fff; border-radius: 5px; padding: 20px;'>" +
                           "<h1 style='text-align: center;'>Confirm Email</h1>" +
                           $"<p>Hello {user.FName},</p>" +
                           $"<p>You recently created account Password:<span style='background-color: black; color: white; padding: 10px 10px'>{password}<span></p>" +
                           "<p>If you did not create an account, please ignore this email.</p>" +
                           "<p>Thanks,</p>" +
                           "<p>SusFaceGen</p>" +
                           "</div>" +
                           "</div>" +
                           "</body>" +
                           "</html>";

                        await _emailSender.SendEmailAsync(Input.Email, "Confirm your email", email);

                        await _emailSender.SendEmailAsync(Input.Email, "Account Password: Please change your password after login", passwordEmail);

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            TempData["StatusMessage"] = "Account added Successfully";
                            return RedirectToAction("userList", "Admin", "");
                            //return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }


        private susFaceGenUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<susFaceGenUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(susFaceGenUser)}'. " +
                    $"Ensure that '{nameof(susFaceGenUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<susFaceGenUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<susFaceGenUser>)_userStore;
        }
    }
}
