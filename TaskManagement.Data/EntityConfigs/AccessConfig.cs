using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Data.Contracts.BaseInfoInitialize;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityConfigs
{
    public class AccessConfig : IEntityTypeConfiguration<Access>
    {
        public void Configure(EntityTypeBuilder<Access> builder)
        {
            builder.Property(p => p.AccessName).HasMaxLength(100).HasColumnType("NVarChar(100)");
        }
    }
}
