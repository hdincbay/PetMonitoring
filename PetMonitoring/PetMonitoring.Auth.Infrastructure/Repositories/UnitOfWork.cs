using PetMonitoring.Auth.Application.Interfaces;
using PetMonitoring.Auth.Infrastructure.Persistence;

namespace PetMonitoring.Auth.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AuthDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public UnitOfWork(AuthDbContext context, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public IUserRepository Users => _userRepository;

        public IRefreshTokenRepository RefreshTokens => _refreshTokenRepository;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
