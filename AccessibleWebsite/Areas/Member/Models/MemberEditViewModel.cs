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
        public string? ImageUrl { get; set; }
        public string? Gender { get; set; }
        public string? Age { get; set; }
        public int Height {  get; set; }
        public int Kilo {  get; set; }
        public string? Branch { get; set; }
        public string? Description { get; set; }
    }
}
