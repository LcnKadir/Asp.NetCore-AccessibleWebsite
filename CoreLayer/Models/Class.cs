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
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

    }
}
