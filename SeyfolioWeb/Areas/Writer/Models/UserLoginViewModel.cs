using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeyfolioWeb.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
    }
}
