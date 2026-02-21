using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Security
{
    public sealed class JwtSettings
    {
        public string Secret { get; set; } = default!;
        public int ExpiryMinutes { get; set; } = 30;
        public string? Issuer { get; internal set; }
        public string? Audience { get; internal set; }
    }
}
