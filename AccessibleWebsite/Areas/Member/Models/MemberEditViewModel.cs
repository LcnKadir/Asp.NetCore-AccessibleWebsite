namespace AccessibleWebsite.Areas.Member.Models
{
    public class MemberEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password {  get; set; }
        public string Confirmpassword { get; set; }
        public string? Email { get; set; }
        public IFormFile Image { get; set; }
        public string? Gender { get; set; }
        public string? Age { get; set; }
    }
}
