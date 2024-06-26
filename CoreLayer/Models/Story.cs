﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Story: BaseEntity
    {
        public string? Description { get; set; } 
        public bool Published { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
