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
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.TitleTwo).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LoginTitle).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(600);
            builder.Property(x => x.DescriptionTwo).IsRequired().HasMaxLength(600);
            builder.Property(x => x.DescriptionThree).IsRequired().HasMaxLength(600);
            builder.Property(x => x.LoginDescription).IsRequired().HasMaxLength(600);
            builder.Property(x => x.LoginDescriptionTwo).IsRequired().HasMaxLength(600);
            builder.Ignore(x => x.ImageUrl);
            builder.Ignore(x => x.CoverImageUrl); 
            builder.Ignore(x => x.ImageUrlTwo);

            
            //Bloğun bir çok yorumu olabilir fakat, bloğun silinmesi halinde ait olduğu yorumlarda silinsin.
            builder.HasMany(x=> x.Comments).WithOne(x=> x.Blog).HasForeignKey(x=>x.BlogId).OnDelete(DeleteBehavior.Cascade); 

		}
    }
}
