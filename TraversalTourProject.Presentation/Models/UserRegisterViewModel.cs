using System.ComponentModel.DataAnnotations;

namespace TraversalTourProject.Presentation.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Email adresini giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre giriniz")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
    }
}
