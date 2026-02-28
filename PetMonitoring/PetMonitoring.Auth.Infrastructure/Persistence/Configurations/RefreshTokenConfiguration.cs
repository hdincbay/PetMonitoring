using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetMonitoring.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Persistence.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();

            builder.Property(x => x.IsRevoked)
                   .IsRequired();

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(y => y.RefreshTokens)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Token)
                   .IsUnique();
        }
    }
}
