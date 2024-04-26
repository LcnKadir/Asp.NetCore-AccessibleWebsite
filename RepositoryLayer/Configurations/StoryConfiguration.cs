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
    public class StoryConfiguration : IEntityTypeConfiguration<Story>


    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.HasOne(x => x.AppUser).WithMany(x => x.Stories).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
