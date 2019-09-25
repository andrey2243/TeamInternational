using ChatTeamInternational.Models.DBModels;
using ChatTeamInternational.Models.VModels;
using ChatTeamInternational.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
       
        UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [EnableCors("AllowAllOrigin")]
        [HttpPost]
        [Route("Login")]
        //[ValidateAntiForgeryToken]
        public IActionResult Login([FromBody]UserVM model)
        {
            //_userService.RegisterUser(model);
            var isValid = _userService.IsUserExist(model);
            if (isValid)
                return Json(model);
            else return Json(null);
        }


        [EnableCors("AllowAllOrigin")]
        [Route("Register")]
        public IActionResult Register([FromBody] UserVM model)
        {
            var isValid = _userService.IsUserExist(model);
            if (isValid == false)
            {
                _userService.RegisterUser(model);
                User user = _userService.MapModels(model);
                user.NickName = user.NickName;
                //var result = await _userManager.CreateAsync(user, model.Password);

                //await _signInManager.SignInAsync(user, false);

                return Json(false);
            }

            else return Json(isValid);

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
