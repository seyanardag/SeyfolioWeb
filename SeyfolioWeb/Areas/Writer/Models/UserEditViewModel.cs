using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeyfolioWeb.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [Display(Name ="Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("e-posta")]
        public string Email { get; set; }
        [DisplayName("e-posta")]
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; } = null;
    }
}
