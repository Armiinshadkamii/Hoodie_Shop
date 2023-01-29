using First_Website.Areas.Identity.Data;
using Hoodie_Shop.Areas.Identity.Data;
using Hoodie_Shop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hoodie_Shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index([FromServices] HoodieDb db)
        {
            ViewData["Hoodies"] = db.hoodies.Where(x=>x.count!=0).Include(x => x.hoodieImgs).ToList();
            return View();
        }
        public async Task<IActionResult> AddToShoppingCart(int id, string name, [FromServices] HoodieDb db, [FromServices] UserManager<ApplicationUser> userManager)
        {
            List<Cart> carts = new List<Cart>();
            carts = db.Carts.Where(x=>x.Name==name).Include(x=>x.CartItems).ToList();
            List<CartItem> cartItems = new List<CartItem>();
            ApplicationUser user = await userManager.FindByNameAsync(name);
            if (user != null)
            {
                Cart cart = new Cart();
                cart.Name = user.UserName;
                CartItem cartItem = new CartItem();
                Hoodie hoodie = db.hoodies.Find(id);
                cartItem.HoodieId = hoodie.id;
                cartItem.CartId = cart.Id;
                cartItems.Add(cartItem);
                cart.CartItems = cartItems;
                cart.UserId = user.Id;
                cart.Price += hoodie.price;
                carts.Add(cart);
                user.Carts = carts;
                
                db.Update(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "home");
            }

        }
        public IActionResult getCartNumber(string usersName,[FromServices] HoodieDb db)
        {
            if(usersName==null)
            {
                return Json(0);
            }
            else
            {
               int cartItemNumberForUser = db.Carts.Count(x => x.Name == usersName);
                return Json(cartItemNumberForUser);
            }
        }
        public IActionResult showImg(int id, [FromServices] HoodieDb db)
        {
            var imgBytes = db.hoodieImgs.Find(id).img;
            return File(imgBytes, "image/jpeg");
        }
    }
}
