using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using ReportBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBook.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Loggin).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(10);

            builder.HasMany(x => x.Reports)
                   .WithOne(x => x.UserEntity)
                   .HasForeignKey(x => x.UserId)
                   .HasPrincipalKey(x => x.Id);
        }
    }
}
