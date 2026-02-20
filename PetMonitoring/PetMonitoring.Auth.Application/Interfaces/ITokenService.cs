using PetMonitoring.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
        RefreshToken GenerateRefreshToken(Guid userId);
    }
}
