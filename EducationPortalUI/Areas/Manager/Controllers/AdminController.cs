using EducationPortalEL.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortalUI.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Route("admin/[Action]/{id?}")]
    public class AdminController:Controller
    {
        private readonly UserManager<AppUser> _userManager;      
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult AdminLogin()
        {
            return View();
        }
        //public IActionResult NewEducationAdd()
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.
        //    }
        //}

    }
}
