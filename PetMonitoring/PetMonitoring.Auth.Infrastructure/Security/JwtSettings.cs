using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Security
{
    public class JwtSettings
    {
        public string Secret { get; set; } = default!;
        public int ExpiryMinutes { get; set; }
    }
}
