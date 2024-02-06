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
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x=> x.Image).IsRequired();


            //Bloğun bir çok yorumu olabilir fakat, bloğun silinmesi halinde ait olduğu yorumlarda silinsin.
            builder.HasMany(x=> x.Comments).WithOne(x=> x.Blog).HasForeignKey(x=>x.BlogId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
