using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Blog> Blogs { get; set; }
       
    }
}
