using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hoodie_Shop.Controllers
{
    [Authorize(Policy ="customerpolicy")]
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
