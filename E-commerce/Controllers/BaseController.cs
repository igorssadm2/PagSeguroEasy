using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace msShop.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public readonly IdentityUser _user;   
        public BaseController(IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _user = _userManager.Users.FirstOrDefault();
        } 
    }
}
