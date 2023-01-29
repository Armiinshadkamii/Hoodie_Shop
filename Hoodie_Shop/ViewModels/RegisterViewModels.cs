using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hoodie_Shop.ViewModels
{
    public class RegisterViewModels
    {
        //user view models
        [Required(ErrorMessage ="نام کاربری نباید خالی یا تکراری باشد")]
        [Remote("CheckUserName","Account",ErrorMessage ="این نام کاربری قبلا استفاده شده است")]
        public string userName { get; set; }
        [Required(ErrorMessage ="نام خود را وارد کنید")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی خود را وارد کنید")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string passWord { get; set; }
        public bool isAnAdmin { get; set; }
        [Required(ErrorMessage ="آیدی را وارد کنید")]
        public string DeleteId { get; set; }
        //product view models
        [Required(ErrorMessage ="نام را وارد کنید")]
        public string name { get; set; }
        [Required(ErrorMessage ="قیمت را وارد کنید")]
        public string price { get; set; }
        [Required(ErrorMessage ="رنگ کالا را وارد کنید")]
        public string color { get; set; }
        [Required(ErrorMessage = " تعداد را وارد کنید")]
        public int count { get; set; }
        [Required(ErrorMessage = "برای کالا عکس اولیه را انتخاب کنید")]
        public byte[] titleImage { get; set; }
        [Required(ErrorMessage ="برای کالا عکس انتخاب کنید")]
        public List<IFormFile> images { get; set; }
        [Required(ErrorMessage = "آیدی را وارد کنید")]
        public int DeleteProductId { get; set; }

    }
}
