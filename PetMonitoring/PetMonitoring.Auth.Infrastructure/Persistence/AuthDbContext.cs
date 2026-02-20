using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetMonitoring.Auth.Domain;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Persistence
{
    public class AuthDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
            base.OnModelCreating(builder);
            builder.Entity<User>(entity =>
            {
                entity.Property(x => x.IsActive)
                      .IsRequired();
            });
        }
    }
}
