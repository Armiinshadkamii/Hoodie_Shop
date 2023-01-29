using Hoodie_Shop.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Website.Areas.Identity.Data
{
    public class HoodieImg
    {
        public int Id { get; set; }
        public byte[] img { get; set; }
        public byte[] thumbNail { get; set; }
        public Hoodie hoodie { get; set; }
        [ForeignKey("hoodieId")]
        public int hoodieId { get; set; }
        
    }
}
