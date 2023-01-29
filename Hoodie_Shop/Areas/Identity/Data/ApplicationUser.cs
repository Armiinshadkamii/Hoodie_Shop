using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Website.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Hoodie_Shop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public ICollection<Orders> Orders { get; set; }
    public ICollection<Cart> Carts { get; set; }

}

