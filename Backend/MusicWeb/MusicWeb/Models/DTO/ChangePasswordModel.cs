using System.ComponentModel.DataAnnotations;

namespace MusicWeb.Models.DTO
{
    public class ChangePasswordModel
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password), Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name ="New Password")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name ="Comfirm New Password")]
        [Compare("NewPassword", ErrorMessage ="Mật khẩu không đúng!")]
        public string ConfirmNewPassword { get; set;}
    }
}
