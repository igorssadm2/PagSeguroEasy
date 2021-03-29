using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Controllers
{
    public class ForgotPasswordController : BaseController
    {
        public ForgotPasswordController(IConfiguration configuration,
            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) : base(configuration, signInManager, userManager)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/Forgot/ResetPassword", Name = "ResetPassword")]
        public void ResetPassword()
        {

        } 
    }
}
