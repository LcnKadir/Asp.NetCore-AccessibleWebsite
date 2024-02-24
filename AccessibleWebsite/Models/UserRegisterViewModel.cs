namespace AccessibleWebsite.Models
{
    public class UserRegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Branch { get; set; }
        public int TrainerId { get; set; }
        public int ConfirmCode { get; set; }
    }
}
