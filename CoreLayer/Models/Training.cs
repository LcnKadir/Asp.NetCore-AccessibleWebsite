using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Training : BaseEntity
    {
        public string Description { get; set; }
        public int AppUserId { get; set; }
        public int? TrainerId { get; set; }
        public string? Branch { get; set; }
        public bool Status { get; set; } //Antreman istek listesinde üyelerin durumu belirtilecek.
        public AppUser AppUser { get; set; }


    }
}
