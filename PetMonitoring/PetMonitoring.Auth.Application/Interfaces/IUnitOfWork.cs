using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRefreshTokenRepository RefreshTokens { get; }

        Task<int> SaveChangesAsync();
    }
}
