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
    internal class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            //Kullanıcı sadece seçtiği tek bir Trainer ile çalışabilecek.
            builder.HasOne(c => c.AppUser).WithOne(u => u.Trainings).HasForeignKey<Training>(c => c.AppUserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
