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
    public class ChangePasswordModel : PageModel
    {
        public IdentityUser _User { get; set; }
        public UserManager<IdentityUser> UserManager { get; set; }
        [BindProperty]
        public ChangePassword Input { get; set; }
        public ChangePasswordModel(UserManager<IdentityUser> userManager)
        {
            this._User = userManager.Users.FirstOrDefault();
            this.UserManager = userManager;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await UserManager.ChangePasswordAsync(this._User, Input.OldPassword, Input.NewPassword);
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


        public class ChangePassword
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name ="Senha")]
            public string OldPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Nova Senha")]
            public string NewPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("NewPassword")]
            [Display(Name = "Confirmar Senha")]
            public string ConfirmPassword    { get; set; }
        }
    }
}
