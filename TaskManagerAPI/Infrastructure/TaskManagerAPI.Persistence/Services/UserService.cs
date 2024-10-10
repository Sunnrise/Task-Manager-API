using Azure.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Application.DTOs.User;
using TaskManagerAPI.Application.Features.User.Exceptions;
using TaskManagerAPI.Application.Interfaces.Services;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Persistence.Services
{
    public class UserService : IUserService
    { readonly UserManager<AppUser> userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            IdentityResult result = await userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                UserName = model.UserName
            }, model.Password);

            AppUser? user = await userManager.FindByEmailAsync(model.Email);

            await userManager.AddToRoleAsync(user, "user");

            CreateUserResponse response = new()
            {
                Succeeded = result.Succeeded,
                Message = result.Succeeded ? "User created successfully" : "User creation failed"
            };
            return response;


        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int AddOnAccessTokenDate)
        {
          
            if (user is not null)
            {
                user.refreshToken = refreshToken;
                user.RefreshTokenExpiryTime = accessTokenDate.AddMinutes(AddOnAccessTokenDate);
                await userManager.UpdateAsync(user);
            }
            else 
                throw new UserNotFoundException();
            
        }


    }
}
