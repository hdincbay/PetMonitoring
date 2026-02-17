using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Domain
{
    public class User : IdentityUser<Guid>
    {
        public bool IsActive { get; set; }
    }
}
