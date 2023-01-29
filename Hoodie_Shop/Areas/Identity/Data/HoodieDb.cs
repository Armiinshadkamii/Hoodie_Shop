using First_Website.Areas.Identity.Data;
using Hoodie_Shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hoodie_Shop.Data;

public class HoodieDb : IdentityDbContext<ApplicationUser>
{
    public DbSet<Orders> orders { get; set; }
    public DbSet<OrdersDetails> ordersDetails { get; set; }
    public DbSet<Hoodie> hoodies { get; set; }
    public DbSet<HoodieImg> hoodieImgs { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public HoodieDb(DbContextOptions<HoodieDb> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
