using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagerAPI.Application.DTOs;
using TaskManagerAPI.Application.Features.User.Exceptions;
using TaskManagerAPI.Application.Interfaces.Services;
using TaskManagerAPI.Application.Interfaces.Token;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Application.Features.User.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        IAuthService authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
           var token = await authService.LoginAsync(request.EmailOrUsername, request.Password, 60);
            return new LoginUserSuccessCommandResponse
            {
                Token = token
            };
        }
    }
}