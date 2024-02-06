using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Trainer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }


        public ICollection<Class> Classes { get; set; }
        public ICollection<Blog> Blogs {  get; set; }
    }
}
