using System.ComponentModel.DataAnnotations.Schema;

namespace First_Website.Areas.Identity.Data
{
    public class OrdersDetails
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string productPrice { get; set; }
        public int totalPrice { get; set; }
        public Orders orders { get; set; }
        [ForeignKey("ordersId")]
        public int ordersId { get; set; }
        public Hoodie hoodie { get; set; }
        [ForeignKey("hoodieId")]
        public int hoodieId { get; set; }


    }
}
