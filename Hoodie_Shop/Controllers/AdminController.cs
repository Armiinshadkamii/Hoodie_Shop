using First_Website.Areas.Identity.Data;
using Hoodie_Shop.Areas.Identity.Data;
using Hoodie_Shop.Data;
using Hoodie_Shop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Hoodie_Shop.Controllers
{
    [Authorize(Policy ="AdminPolicy")]
    public class AdminController : Controller
    {
       public IActionResult index([FromServices]HoodieDb db)
       {
            ViewData["usersList"]=db.Users.ToList();
            ViewData["products"] = db.hoodies.ToList().Where(x=>x.count!=0).ToList();
            ViewData["notAvailable"]=db.hoodies.ToList().Where(x=>x.count==0).ToList();
            return View();
       }
    }
}
