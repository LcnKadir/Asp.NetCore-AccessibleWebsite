using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TrainerId { get; set; }
        public Trainer Trainer { get; set; }


        public ICollection<Comment> Comments { get; set; }
    }
}
