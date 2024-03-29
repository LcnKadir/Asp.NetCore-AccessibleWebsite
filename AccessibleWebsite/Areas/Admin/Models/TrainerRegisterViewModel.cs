﻿namespace AccessibleWebsite.Areas.Admin.Models
{
    public class TrainerRegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Branch { get; set; }
        public int TrainerId { get; set; }
    }
}
