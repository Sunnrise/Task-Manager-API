using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagerAPI.Application.DTOs;
using TaskManagerAPI.Application.Features.User.Exceptions;
using TaskManagerAPI.Application.Interfaces.Services;
using TaskManagerAPI.Application.Interfaces.Token;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Persistence.Services
{

    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> userManager;
        readonly SignInManager<AppUser> signInManager;
        readonly ITokenHandler tokenHandler;
        readonly IUserService userService;


        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenHandler = tokenHandler;
            this.userService = userService;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser user = await userManager.FindByEmailAsync(usernameOrEmail);
            if (user is null)
                user = await userManager.FindByNameAsync(usernameOrEmail);
            if (user is null)
                throw new UserNotFoundException();

            SignInResult result = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Token token = tokenHandler.CreateAccessToken(accessTokenLifeTime);

                await userService.UpdateRefreshToken(token.RefreshToken, user, token.ExpiryDate,15);
                return token;
            }

            throw new AuthenticationErrorException();

        }

        

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
           AppUser? user = await  userManager.Users.FirstOrDefaultAsync(u => u.refreshToken == refreshToken);

            if (user is not null&& user?.RefreshTokenExpiryTime>DateTime.UtcNow)
            {
               Token token= tokenHandler.CreateAccessToken(15);
               await  userService.UpdateRefreshToken(token.RefreshToken, user, token.ExpiryDate, 15);
                return token;
            }
            else
                throw new UserNotFoundException();

        }
    }
}
