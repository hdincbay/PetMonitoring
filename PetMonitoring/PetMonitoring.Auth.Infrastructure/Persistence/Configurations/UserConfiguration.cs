using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetMonitoring.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.Property(x => x.PasswordHash)
                   .IsRequired();
            builder.Property(x => x.IsActive)
                      .IsRequired();
        }
    }
}
