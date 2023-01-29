using Hoodie_Shop.Areas.Identity.Data;
using Hoodie_Shop.Data;

namespace First_Website.Areas.Identity.Data
{
    public class Hoodie
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int count { get; set; }
        public string color { get; set; }
        public bool isAvailable { get; set; }
        public ICollection<HoodieImg> hoodieImgs { get; set; }
        public ICollection<OrdersDetails> OrdersDetails { get; set; }
        public byte[] titleImage { get; set; }
        public byte[] thumbNailTitleImg { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
