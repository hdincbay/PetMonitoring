using MediatR;
using Microsoft.AspNetCore.Identity;
using PetMonitoring.Auth.Domain.Entities;
using PetMonitoring.Auth.Application.Interfaces;

namespace PetMonitoring.Auth.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;

        public LoginCommandHandler(
            IUnitOfWork unitOfWork,
            ITokenService tokenService,
            SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
                throw new UnauthorizedAccessException("Invalid credentials");
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);
            user.AddRefreshToken(refreshToken);

            await _unitOfWork.RefreshTokens.AddAsync(refreshToken);

            await _unitOfWork.SaveChangesAsync();

            return new LoginResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }
    }
}