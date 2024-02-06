using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class AccessibleUser: BaseEntity
    {
        public string Name { get; set; }
        public string Surname {  get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
    }
}
