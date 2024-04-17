using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class AppUser : IdentityUser<int>
    {

        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? Image { get; set; }

        public bool? Status {  get; set; } //Kullanıcı erişilebilir sayfaya geçmesi durumunda, hesabı true olacak.
        public string? Gender { get; set; }
        public string? Age { get; set; }
        public int Height { get; set; }
        public int Kilo {  get; set; }       
        public int ConfirmCode { get; set; }

        //Trainerlar ile User tek bir tabloda birleştirildi.
        public int? TrainerId { get; set; }
        public string? Branch { get; set; } //Kullanıcı kayıt olduğunda branch alanı otomatik; "null" olarak doldurulacak. Trainer için doldurulması zorunlu olacak.
        public string? Description { get; set; }


        public ICollection<Class> Classes { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public Message Messages { get; set; }
        public Training Trainings { get; set; }  //Bire bir ilişki kurularak, kullanıcının sadece seçtiği tek bir Trainer ile çalışması sağlanacak.

    }
}
