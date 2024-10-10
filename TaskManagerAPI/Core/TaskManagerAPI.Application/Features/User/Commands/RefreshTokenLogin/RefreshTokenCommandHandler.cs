using MediatR;
using TaskManagerAPI.Application.DTOs;
using TaskManagerAPI.Application.Interfaces.Services;

namespace TaskManagerAPI.Application.Features.User.Commands.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {  readonly IAuthService authService;

        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            this.authService = authService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new()
            {
                Token = token,
            };
        }
    }
}
