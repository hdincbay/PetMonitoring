using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetMonitoring.DeviceManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PetMonitoring.DeviceManagement.Infrastructure.Persistence.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<DeviceRecord>
    {
        public void Configure(EntityTypeBuilder<DeviceRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedDate)
                  .IsRequired();
        }
    }
}
