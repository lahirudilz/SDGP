// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using susFaceGen.Areas.Identity.Data;

namespace susFaceGen.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<susFaceGenUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordModel(UserManager<susFaceGenUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                var emailBody = "<!DOCTYPE html><html lang='en''><head><meta charset='UTF-8'>" +
                    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
                    "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
                    "<title>Password Reset</title>" +
                    "</head>" +
                    "<body>" +
                    "<div style='background-color: #f4f4f4; padding: 20px;'>" +
                    "<div style='background-color: #fff; border-radius: 5px; padding: 20px;'>" +
                    "<h1 style='text-align: center;'>Password Reset</h1>" +
                    $"<p>Hello {user.FName},</p>" +
                    "<p>You recently requested to reset your password for your account. Click the link below to reset it.</p>" +
                    $"<p><a href='{HtmlEncoder.Default.Encode(callbackUrl)}' style='background-color: #4CAF50; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px;'>Reset Password</a></p>" +
                    "<p>If you did not request a password reset, please ignore this email.</p>" +
                    "<p>Thanks,</p>" +
                    "<p>SusFaceGen</p>" +
                    "</div>" +
                    "</div>" +
                    "</body>" +
                    "</html>";

                await _emailSender.SendEmailAsync(
                    Input.Email,
                    "Reset Password", emailBody
                    );

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
