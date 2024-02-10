using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DTOs
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string UserName { get; set; }
    }
}
