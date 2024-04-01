using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class Message : BaseEntity
    {
        public int AppUserId { get; set; }
        public int ClassId { get; set; }
        public bool ClassRegistering { get; set; } //Kullanıcı haftalık bir derse katılma hakkına sahip olacak. Derse katılmak istediğini bildirdiği zaman, eklenme durumu true dönecek.
        public AppUser AppUser { get; set; }
        public Class Class { get; set; }
    }
}
