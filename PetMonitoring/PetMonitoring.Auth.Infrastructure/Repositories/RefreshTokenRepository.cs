using Microsoft.EntityFrameworkCore;
using PetMonitoring.Auth.Application.Interfaces;
using PetMonitoring.Auth.Domain.Entities;
using PetMonitoring.Auth.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AuthDbContext _context;

        public RefreshTokenRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(RefreshToken refreshToken) => await _context.RefreshTokens.AddAsync(refreshToken);

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x =>
                    x.Token == token &&
                    !x.IsRevoked &&
                    x.ExpiresAt > DateTime.UtcNow);
        }

        public async Task UpdateAsync(RefreshToken refreshToken) => _context.RefreshTokens.Update(refreshToken);
    }
}
