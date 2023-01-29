using First_Website.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hoodie_Shop.Areas.Identity.Data
{
    public class CartItem
    {
        public int Id { get; set; }
        public Hoodie Hoodie { get; set; }
        [ForeignKey("HoodieId")]
        public int HoodieId { get; set; }
        public Cart Cart { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }
    }
}
