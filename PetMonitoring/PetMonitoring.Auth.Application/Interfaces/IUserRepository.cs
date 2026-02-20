using PetMonitoring.Auth.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        void Update(User user);
    }
}
