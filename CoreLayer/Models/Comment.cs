using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Comment : BaseEntity
    {
        public string CommentContent { get; set; }

        public int BlogId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Blog Blog { get; set; }

    }
}
