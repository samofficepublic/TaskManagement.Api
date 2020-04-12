using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityConfigs
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.BirthDay).IsRequired(false);
            builder.Property(x => x.Email).HasMaxLength(250);
            builder.Property(x => x.FirstName).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.MobileNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(300);
            builder.HasIndex(i => i.UniqueId).IsUnique().IsUnique();
            builder.Property(p => p.UniqueId).HasDefaultValue(Guid.NewGuid());
        }
    }
}
