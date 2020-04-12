using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entity.Common;
using TaskManagement.Entity.DomainModels;

namespace TaskManagement.Data.EntityConfigs
{
    public class TicketConfig:IEntityTypeConfiguration<Ticket> 
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.Property(x => x.Subject).HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(4000);
            builder.HasIndex(i => i.UniqueId).IsUnique().IsUnique();
            builder.Property(p => p.UniqueId).HasDefaultValue(Guid.NewGuid());
        }
    }
}
