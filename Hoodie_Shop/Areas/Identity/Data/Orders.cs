using Hoodie_Shop.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Website.Areas.Identity.Data
{
    public class Orders
    {
        public int id { get; set; }
        public string RegisterDate { get; set; }
        public string DeliverDate { get; set; }
        public ApplicationUser user { get; set; }
        [ForeignKey("userId")]
        public string userId { get; set; }
        public ICollection<OrdersDetails> OrdersDetails { get; set; }
    }
}
