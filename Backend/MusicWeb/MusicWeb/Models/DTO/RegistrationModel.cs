using System.ComponentModel.DataAnnotations;

namespace MusicWeb.Models.DTO
{
    public class RegistrationModel
    {
        [Required(ErrorMessage ="Vui lòng nhập tên người dùng!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập địa chỉ Email!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nhập tên tài khoản đăng nhập!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,}$",
        //ErrorMessage = "Vui lòng nhập mật khẩu phải bao gồm 5 kí tự và kí tự đặc biệt!")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Vui lòng xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage ="Mật khẩu không chính xác!")]
        public string PasswordConfirmed { get; set; }
        public string ? Role { get; set; }
    }
}
