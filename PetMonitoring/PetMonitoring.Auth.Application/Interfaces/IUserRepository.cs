using PetMonitoring.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName);
        Task<User?> GetByIdAsync(Guid id);
        public Task<IList<string>> GetUserRolesAsync(User user);
        Task AddAsync(User user);
        void Update(User user);
    }
}
