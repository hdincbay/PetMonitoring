using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PetMonitoring.Auth.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        protected User() { }

        private readonly List<RefreshToken> _refreshTokens = new();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

        public bool IsActive { get; private set; } = true;

        public void AddRefreshToken(RefreshToken refreshToken)
        {
            if (refreshToken == null)
                throw new ArgumentNullException(nameof(refreshToken));

            _refreshTokens.Add(refreshToken);
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}