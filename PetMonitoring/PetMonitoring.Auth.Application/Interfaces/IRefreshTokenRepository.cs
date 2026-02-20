using PetMonitoring.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken refreshToken);
        Task<RefreshToken?> GetByTokenAsync(string token);
        Task UpdateAsync(RefreshToken refreshToken);
    }
}
