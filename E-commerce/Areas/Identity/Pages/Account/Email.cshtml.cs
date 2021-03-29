using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Areas.Identity.Pages.Account
{
    public class ChangeEmailModel : PageModel
    {
        public IdentityUser _User { get; set; }
        public UserManager<IdentityUser> UserManager { get; set; }
        [BindProperty]
        public ChangeEmail Input { get; set; }
        public ChangeEmailModel(UserManager<IdentityUser> userManager)
        {
            this._User = userManager.Users.FirstOrDefault();
            this.UserManager = userManager;
            Input = new ChangeEmail();  
        }
        public IActionResult OnGet()
        {
            Input.OldEmail = _User.Email;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var emailToken = UserManager.GenerateChangeEmailTokenAsync(_User, Input.NewEmail);
               
                var result = await UserManager.ChangeEmailAsync(this._User, Input.NewEmail, emailToken.Result);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("ChangeSenha", "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public class ChangeEmail
        {
            [Required]
            [Display(Name ="E-mail")]
            [DataType(DataType.EmailAddress)]
            public string OldEmail { get; set; }

            [Required]
            [Display(Name = "Novo E-mail")]
            [DataType(DataType.EmailAddress)]
            public string NewEmail { get; set; }

        }

    }
}
