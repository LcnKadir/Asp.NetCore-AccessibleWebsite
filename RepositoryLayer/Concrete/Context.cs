using CoreLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Concrete
{
    public class Context : DbContext
    {
        //Veri tabanının bağlantı yolu Program.cs'e yönlendirildi.
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }


        //Entity'lerimize köprü oluşturarak, SQL'e kaydedilmesi sağlanacak.
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AccessibleUser> AccessibleUsers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }


        //Configuration ile eklenen tüm işlemlerinin okuması gerçekleşecek.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
