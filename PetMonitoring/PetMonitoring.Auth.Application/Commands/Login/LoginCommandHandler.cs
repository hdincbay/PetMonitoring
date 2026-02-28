using MediatR;
using Microsoft.AspNetCore.Identity;
using PetMonitoring.Auth.Domain.Entities;
using PetMonitoring.Auth.Application.Interfaces;
using PetMonitoring.Auth.Application.Enums;

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
            var user = await _unitOfWork.Users.GetByUserNameAsync(request.UserName!);
            if (user == null)
                return new LoginResult(message: "User not found!", status: RequestStatus.Failed);
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
                return new LoginResult(message: "Invalid credentials", status: RequestStatus.ValidationError);
            var roles = await _unitOfWork.Users.GetUserRolesAsync(user);
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(user.Id);
            user.AddRefreshToken(refreshToken);

            await _unitOfWork.RefreshTokens.AddAsync(refreshToken);

            await _unitOfWork.SaveChangesAsync();

            return new LoginResult(
                accessToken: accessToken, 
                refreshToken: refreshToken.Token,
                message: "Login successful",
                status: RequestStatus.Success,
                userId: user.Id,
                userName: user.UserName,
                roles: roles
            );
        }
    }
}