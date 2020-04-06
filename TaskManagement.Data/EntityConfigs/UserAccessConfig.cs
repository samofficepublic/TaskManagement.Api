using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityConfigs
{
    public class UserAccessConfig:IEntityTypeConfiguration<UserAccess>
    {
        public void Configure(EntityTypeBuilder<UserAccess> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Accesses)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true);

            builder
                .HasOne(x => x.Access)
                .WithMany(x => x.Accesses)
                .HasForeignKey(x => x.AccessId)
                .IsRequired(true);
        }
    }
}
