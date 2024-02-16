using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Blog : BaseEntity
    {
        public string LoginTitle { get; set; }
        public string Title { get; set; }
        public string TitleTwo { get; set; }
        public string LoginDescription { get; set; }
        public string LoginDescriptionTwo { get; set; }
        public string? Description { get; set; }
        public string DescriptionTwo { get; set; }
        public string DescriptionThree { get; set; }
        public string Image { get; set; }
        public string ImageTwo { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string CoverImage { get; set; }
        public IFormFile? CoverImageUrl { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
