using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class About: BaseEntity
    {
        public string Description {  get; set; }
        public string Title { get; set; }
    }
}
