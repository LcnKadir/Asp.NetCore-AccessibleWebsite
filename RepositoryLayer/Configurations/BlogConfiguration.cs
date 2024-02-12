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
    internal class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Ignore(x => x.Image);


            //Bloğun bir çok yorumu olabilir fakat, bloğun silinmesi halinde ait olduğu yorumlarda silinsin.
            builder.HasMany(x=> x.Comments).WithOne(x=> x.Blog).HasForeignKey(x=>x.BlogId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
