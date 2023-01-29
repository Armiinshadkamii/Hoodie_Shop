using First_Website.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoodie_Shop.Areas.Identity.Data
{
    public class Cart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int count { get; set; }
        public int Price { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
