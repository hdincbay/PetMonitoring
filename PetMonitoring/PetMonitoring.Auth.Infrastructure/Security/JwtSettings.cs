using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Security
{
    public sealed class JwtSettings
    {
        public string Secret { get; set; } = default!;
        public int ExpiryMinutes { get; set; }
    }
}
