using System.ComponentModel.DataAnnotations;
namespace Hoodie_Shop.ViewModels
{
    public class LoginVewModel
    {
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
