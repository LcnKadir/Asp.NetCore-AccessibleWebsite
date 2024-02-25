using System.ComponentModel.DataAnnotations;

namespace AccessibleWebsite.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "KullanıcıAdı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mail alanı boş geçilemez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Branş alanı geçilemez")]
        public string Branch { get; set; }


        public int TrainerId { get; set; }
        public int ConfirmCode { get; set; }

    }
}
