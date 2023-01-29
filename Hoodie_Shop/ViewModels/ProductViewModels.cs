namespace Hoodie_Shop.ViewModels
{
    public class ProductViewModels
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string color { get; set; }
        public List<IFormFile> images { get; set; }
    }
}
