using BitirmeProjesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesi.Controllers
{
    public class UsersController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {

            return View(_userManager.Users);
        }
        public IActionResult Create()
        {
            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                     var userRoleExists = await _roleManager.RoleExistsAsync("Uye");
                     if (!userRoleExists)
                {
                   
                    await _roleManager.CreateAsync(new IdentityRole("Uye"));
                }
                    await _userManager.AddToRoleAsync(user, "Uye");
                    return RedirectToAction("Login");
                }
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View();
        }
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated){
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre geçersiz.");
                }
            }

            return View(model);
        }

         [HttpPost]
    public async Task<IActionResult> CikisYap()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }


    }
}