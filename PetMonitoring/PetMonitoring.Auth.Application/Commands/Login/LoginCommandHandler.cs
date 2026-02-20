using MediatR;
using PetMonitoring.Auth.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<LoginResult> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users
                .GetByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var validPassword = _passwordHasher.Verify(
                request.Password, user.PasswordHash!);

            if (!validPassword)
                throw new UnauthorizedAccessException("Invalid credentials");

            var accessToken = _tokenService.GenerateAccessToken(user);

            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);
            user.AddRefreshToken(refreshToken);

            await _unitOfWork.SaveChangesAsync();

            return new LoginResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }
    }
}
