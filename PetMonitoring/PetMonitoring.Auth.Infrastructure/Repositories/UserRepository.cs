using Microsoft.EntityFrameworkCore;
using PetMonitoring.Auth.Application.Interfaces;
using PetMonitoring.Auth.Domain.Entities;
using PetMonitoring.Auth.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;

        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public async Task<User?> GetByEmailAsync(string email) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.FindAsync(id);

        public void Update(User user) => _context.Users.Update(user);
    }
}
