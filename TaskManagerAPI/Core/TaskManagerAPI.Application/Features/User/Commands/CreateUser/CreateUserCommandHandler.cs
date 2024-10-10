using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManagerAPI.Application.DTOs.User;
using TaskManagerAPI.Application.Features.User.Exceptions;
using TaskManagerAPI.Application.Interfaces.Services;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService userService;
        readonly IMapper mapper;

        public CreateUserCommandHandler( IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response= await userService.CreateAsync(new()
            {
                Email=request.Email,
                UserName = request.UserName,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
            });

            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }


    }
}