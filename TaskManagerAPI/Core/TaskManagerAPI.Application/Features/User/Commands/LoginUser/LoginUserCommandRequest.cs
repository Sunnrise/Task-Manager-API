using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.Features.User.Commands.LoginUser
{
    public class LoginUserCommandRequest: IRequest<LoginUserCommandResponse>
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}
