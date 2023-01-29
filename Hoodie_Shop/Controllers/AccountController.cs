using Hoodie_Shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Hoodie_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Hoodie_Shop.Data;

namespace Hoodie_Shop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterConfirm(RegisterViewModels models, [FromServices] UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = await userManager.FindByNameAsync(models.userName);
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = models.userName,
                    Email = models.userName,
                    firstName = models.firstName,
                    lastName = models.lastName,
                    EmailConfirmed = true
                };
               var status = await userManager.CreateAsync(user,models.passWord);
                if(models.isAnAdmin==true)
                {
                    if(await userManager.IsInRoleAsync(user, "admins")==false)
                    {
                        await userManager.AddToRoleAsync(user, "admins");
                    }
                }
                else
                {
                    if( await userManager.IsInRoleAsync(user, "customers")==false)
                    {
                        await userManager.AddToRoleAsync(user, "customers");
                    }
                }
                if(status.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("Register");
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginConfirm(LoginVewModel model, [FromServices] UserManager<ApplicationUser> userManager, [FromServices] SignInManager<ApplicationUser>signInManager)
        {
            ApplicationUser user = await userManager.FindByNameAsync(model.UserName);
            if(user!=null)
            {
                await signInManager.PasswordSignInAsync(user, model.Password, false, false);//user.identity.isAuthenticated , user.identity.name
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Register", "Account");
        }
        public async Task<IActionResult> Logout([FromServices]SignInManager<ApplicationUser>signInManager)
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult UsersCount([FromServices] HoodieDb db)
        {
            var count = db.Users.Count();
            return Json(count);
        }
        public IActionResult SelectUsers([FromServices] HoodieDb db)
        {
            var users = db.Users.ToList();
            return Json(users);
        }
        public IActionResult RemoveUser()
        {
            return View();
        }
        public async Task<IActionResult> DeleteUsers(string id, [FromServices] HoodieDb db, [FromServices] UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return RedirectToAction("index", "Admin");
            }
            else
            {
                return RedirectToAction("index", "Admin");
            }
        }
        public IActionResult CheckUserName(string username, [FromServices] HoodieDb db)
        {
            var countOfUserName = db.Users.ToList().Count(x => x.UserName.ToLower() == username.ToLower());
            if(countOfUserName==0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public async Task<IActionResult> DeleteAdmins(string id, [FromServices]UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.FindByIdAsync(id);
            if (admin != null)
            {
                await userManager.DeleteAsync(admin);
                return RedirectToAction("index", "Admin");
            }
            else
            {
                return RedirectToAction("index", "Admin");
            }
        }
    }
}
