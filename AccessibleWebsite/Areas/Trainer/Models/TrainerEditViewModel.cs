namespace AccessibleWebsite.Areas.Trainer.Models
{
    public class TrainerEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string? Email { get; set; }
        public IFormFile Image { get; set; }
 
    }
}
