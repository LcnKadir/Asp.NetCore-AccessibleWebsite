using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);


            //Trainer'ın silinmesi halinde ona ait tüm bloglar silinecek.
            builder.HasMany(u => u.Blogs).WithOne(b => b.AppUser).HasForeignKey(b => b.AppUserId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
