using CoreLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=> x.CommentContant).IsRequired();


            //Kullanıcının bir çok yorumu olabilir. Kullanıcının silinmesi halinde ona ait yorumlarda silinsin.
            builder.HasOne(x=> x.AppUser).WithMany(x=> x.Comments).HasForeignKey(x=>x.AppUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
