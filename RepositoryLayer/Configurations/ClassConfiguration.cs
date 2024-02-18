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
    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Ignore(x => x.ImageUrl);

            //Bir Trainer, bir çok ders açabilir.
            builder.HasOne(x=> x.AppUser).WithMany(x=> x.Classes).HasForeignKey(x=> x.AppUserId).OnDelete(DeleteBehavior.Cascade);  
		}
    }
}
