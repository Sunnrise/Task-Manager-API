using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPI.Application.DTOs;
using TaskManagerAPI.Domain.Entities.Identity;

namespace TaskManagerAPI.Application.Interfaces.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute);
        string CreateRefreshToken();
    }
}
