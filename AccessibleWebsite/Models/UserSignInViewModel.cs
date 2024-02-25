using System.ComponentModel.DataAnnotations;

namespace AccessibleWebsite.Models
{
	public class UserSignInViewModel
	{
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }

    }
}
