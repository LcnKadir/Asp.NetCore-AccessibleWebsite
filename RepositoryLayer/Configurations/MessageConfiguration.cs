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
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MessageContent).IsRequired();

            //Kullanıcı sadece haftalık derslerden birine katılabilecek.
            builder.HasOne(c => c.AppUser).WithOne(u => u.Messages).HasForeignKey<Message>(c => c.AppUserId).OnDelete(DeleteBehavior.NoAction);

            
        }
    }
}
