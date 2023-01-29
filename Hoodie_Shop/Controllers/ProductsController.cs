using First_Website.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Hoodie_Shop.Data;
using Hoodie_Shop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Hoodie_Shop.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Insert()
        {
            return View();
        }
        public IActionResult InsertConfirm(string name,int price,string color,int count, IFormFile titleImg, List<IFormFile>listOfImages, [FromServices] HoodieDb db)
        {
            Hoodie hoodie = new Hoodie();
            hoodie.name =name;
            hoodie.price =price;
            hoodie.color = color;
            hoodie.count =count;
            hoodie.isAvailable = true;
            byte[] titleImageBytes = new byte[titleImg.Length];
            titleImg.OpenReadStream().Read(titleImageBytes, 0, titleImageBytes.Length);
            hoodie.titleImage = titleImageBytes;
            MemoryStream TitleImgMemoryStream = new MemoryStream(titleImageBytes);
            Image imageForTitleImage = Image.FromStream(TitleImgMemoryStream);
            Bitmap bitmap = new Bitmap(imageForTitleImage,200,200*imageForTitleImage.Width / imageForTitleImage.Height);
            MemoryStream memoryStreamForTitleImg = new MemoryStream();
            bitmap.Save(memoryStreamForTitleImg, System.Drawing.Imaging.ImageFormat.Jpeg);
            hoodie.thumbNailTitleImg = memoryStreamForTitleImg.ToArray();
            hoodie.hoodieImgs = new List<HoodieImg>();
            listOfImages.ForEach(x =>
            {
                if (x != null)
                {
                    byte[] bytes = new byte[x.Length];
                    x.OpenReadStream().Read(bytes, 0, bytes.Length);
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    Image image = Image.FromStream(memoryStream);
                    Bitmap bitmap = new Bitmap(image, 200, 200 * image.Width / image.Height);
                    MemoryStream memoryStream1 = new MemoryStream();
                    bitmap.Save(memoryStream1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    HoodieImg hoodieImg = new HoodieImg()
                    {
                        img = bytes,
                        thumbNail = memoryStream1.ToArray()
                    };
                    hoodie.hoodieImgs.Add(hoodieImg);
                }
            });
            db.Add(hoodie);
            db.SaveChanges();
            //return Json("successful!!!");
            return RedirectToAction("index", "Admin");
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult DeleteProducts(int id, [FromServices] HoodieDb db)
        {
            var product = db.hoodies.Find(id);
            if (product != null)
            {
                product.count = 0;
                db.SaveChanges();
                return RedirectToAction("index", "Admin");
            }
            else
            {
                return RedirectToAction("index", "Admin");
            }
        }
        public IActionResult SelectProducts([FromServices] HoodieDb db)
        {
            var products = db.hoodies.ToList();
            return Json(products);
        }
        public IActionResult ProductsCount([FromServices] HoodieDb db)
        {
            var count = db.hoodies.Count();
            return Json(count);
        }
    }
}
