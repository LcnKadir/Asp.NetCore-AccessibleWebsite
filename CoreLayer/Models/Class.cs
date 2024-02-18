using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public string? Image {  get; set; }
        public IFormFile ImageUrl { get; set; }
        public DateTime StartClass { get; set; }
        public DateTime FinishClass { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
