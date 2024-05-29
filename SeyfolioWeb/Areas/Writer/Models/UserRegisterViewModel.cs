using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeyfolioWeb.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [DisplayName("Adınız")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [DisplayName("Soyadınız")]

        public string Surname { get; set; }
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [DisplayName("Kullanıcı adınız")]
        public string UserName { get; set; }
        [DisplayName("Resim yolu")]         
        [Required(ErrorMessage ="Bu alan zorunludur")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifreniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [Compare(nameof(Password),ErrorMessage ="Girdiğiniz şifreler aynı değil, lütfen kontrol ediniz")]
        [DisplayName("Şifrenizi tekrar giriniz")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("e-posta adresiniz")]
        public string Mail { get; set; }
    }
}
